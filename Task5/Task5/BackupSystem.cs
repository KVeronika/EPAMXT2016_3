using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Task5
{
    public class BackupSystem
    {
        public static Logger logger = new Logger();
        public static void PrepareForTracking(string trackingDirectory)
        {
            if (!Directory.Exists(Constants.CopiedFolderPath))
            {
                Directory.CreateDirectory(Constants.CopiedFolderPath);
                CopyFilesAndFolders(trackingDirectory, Constants.CopiedFolderPath);
            }
            if (!File.Exists(Constants.LogFilePath))
            {
                File.Create(Constants.LogFilePath).Close();
            }
            if (!Directory.Exists(SettingsFromConfig.ReadSetting(Constants.folderForCopyFilesKey)))
            {
                Directory.CreateDirectory(SettingsFromConfig.ReadSetting(Constants.folderForCopyFilesKey));
            }
        }

        public static void TrackChanges(string path)
        {
            InitializeFileWatcher(path);
            InitializeFolderWatcher(path);

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        public static void Backup(string trackingFolderPath, DateTime dateAndTime)
        {
            ClearTrackingFolder(trackingFolderPath);
            CopyFilesAndFolders(Constants.CopiedFolderPath, trackingFolderPath);
            List<LogItem> logItems = Logger.ParseLogFile();
            Backuper backuper = new Backuper();
            var logLessThanDate = logItems.Where(item => item.TimeOfChanges <= dateAndTime);
            foreach (var item in logLessThanDate)
            {
                switch (item.TypeOfChanges)
                {
                    case "Changed":
                        {
                            backuper.BackupForChange(item);
                            break;
                        }
                    case "Created":
                        {
                            backuper.BackupForCreate(item);
                            break;
                        }
                    case "Deleted":
                        {
                            backuper.BackupForDelete(item);
                            break;
                        }
                    case "Renamed":
                        {
                            backuper.BackupForRename(item);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (!Directory.Exists(e.FullPath))
                    {
                        DateTime dateTimeOfChange = DateTime.Now;
                        string dateForLog = dateTimeOfChange.ToString(Constants.dateFormat);
                        string logGuid = Guid.NewGuid().ToString();
                        logger.WriteChangeOfFile(e, dateForLog, logGuid);

                        string nameFile = ($"{dateForLog}_{logGuid}.txt");
                        string pathToCopy = Path.Combine(SettingsFromConfig.ReadSetting(Constants.folderForCopyFilesKey), nameFile);
                        File.Copy(e.FullPath, pathToCopy);
                        return;
                    }
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnCreateOrDelete(object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    DateTime dateTimeOfChange = DateTime.Now;
                    string dateForLog = dateTimeOfChange.ToString(Constants.dateFormat);
                    if ((source as FileSystemWatcher).NotifyFilter.HasFlag(NotifyFilters.FileName))
                    {
                        logger.WriteCreateOrDeleteFile(e, dateForLog);
                    }
                    else
                    {
                        logger.WriteCreateOrDeleteFolder(e, dateForLog);
                    }
                    return;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            while (true)
            {
                try
                {
                    DateTime dateTimeOfChange = DateTime.Now;
                    string dateForLog = dateTimeOfChange.ToString(Constants.dateFormat);
                    if ((source as FileSystemWatcher).NotifyFilter.HasFlag(NotifyFilters.FileName))
                    {
                        logger.WriteRenameFile(e, dateForLog);
                    }
                    else
                    {
                        logger.WriteRenameFolder(e, dateForLog);
                    }
                    return;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void InitializeFolderWatcher(string path)
        {
            FileSystemWatcher folderWatcher = new FileSystemWatcher(path);
            folderWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.DirectoryName;
            folderWatcher.Created += new FileSystemEventHandler(OnCreateOrDelete);
            folderWatcher.Deleted += new FileSystemEventHandler(OnCreateOrDelete);
            folderWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            folderWatcher.IncludeSubdirectories = true;
            folderWatcher.EnableRaisingEvents = true;
            folderWatcher.InternalBufferSize = 1024 * 1024;
        }

        private static void InitializeFileWatcher(string path)
        {
            FileSystemWatcher fileWatcher = new FileSystemWatcher(path, "*.txt");
            fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName;
            fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileWatcher.Created += new FileSystemEventHandler(OnCreateOrDelete);
            fileWatcher.Deleted += new FileSystemEventHandler(OnCreateOrDelete);
            fileWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.EnableRaisingEvents = true;
            fileWatcher.InternalBufferSize = 1024 * 1024;
        }

        private static void CopyFilesAndFolders(string trackingDirectory, string copiedDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(trackingDirectory);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + trackingDirectory);
            }

            if (!Directory.Exists(copiedDirectory))
            {
                Directory.CreateDirectory(copiedDirectory);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(copiedDirectory, file.Name);
                file.CopyTo(temppath, false);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(copiedDirectory, subdir.Name);
                CopyFilesAndFolders(subdir.FullName, temppath);
            }
        }

        private static void ClearTrackingFolder(string trackingFolderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(trackingFolderPath);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subdir in dirs)
            {
                Directory.Delete(subdir.FullName, true);
            }
        }
    }
}