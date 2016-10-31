using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Task5
{
    public class BackupSystem
    {
        public static string LogFilePath { get; set; }
        public static string CopiedFolderPath { get; set; }
        public static string utilityFolder = @"C:\Users\Veronika\Desktop\Task5";
        public static string folderForCopyFiles = @"C:\Users\Veronika\Desktop\Task5\CopyOfFiles";

        private BackupSystem(string trackingDirectory)
        {
            DirectoryInfo trackingDir = new DirectoryInfo(trackingDirectory);
            LogFilePath = Path.Combine(utilityFolder, "log.txt");
            CopiedFolderPath = Path.Combine(utilityFolder, trackingDir.Name);
        }

        public static void PrepareForTracking(string trackingDirectory)
        {
            BackupSystem backup = new BackupSystem(trackingDirectory);
            if (!Directory.Exists(CopiedFolderPath))
            {
                Directory.CreateDirectory(CopiedFolderPath);
                CopyFilesAndFolders(trackingDirectory, CopiedFolderPath);
            }
            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath).Close();
            }
            if (!Directory.Exists(folderForCopyFiles))
            {
                Directory.CreateDirectory(folderForCopyFiles);
            }
        }

        public static void TrackChanges(string path)
        {
            FileSystemWatcher fileWatcher = new FileSystemWatcher(path, "*.txt");
            fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName;
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileWatcher.Created += new FileSystemEventHandler(OnCreateOrDelete);
            fileWatcher.Deleted += new FileSystemEventHandler(OnCreateOrDelete);
            fileWatcher.Renamed += new RenamedEventHandler(OnRenamed);

            FileSystemWatcher folderWatcher = new FileSystemWatcher(path);
            folderWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.DirectoryName;
            folderWatcher.IncludeSubdirectories = true;
            folderWatcher.Created += new FileSystemEventHandler(OnCreateOrDelete);
            folderWatcher.Deleted += new FileSystemEventHandler(OnCreateOrDelete);
            folderWatcher.Renamed += new RenamedEventHandler(OnRenamed);

            fileWatcher.EnableRaisingEvents = true;
            folderWatcher.EnableRaisingEvents = true;
            fileWatcher.InternalBufferSize = 1024 * 1024;
            
            fileWatcher.InternalBufferSize = 1024 * 1024;

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        public static void Backup(string trackingFolderPath, DateTime dateAndTime)
        {
            ClearTrackingFolder(trackingFolderPath);
            CopyFilesAndFolders(CopiedFolderPath, trackingFolderPath);
            List<LogFile> logItems = new List<LogFile>();
            using (StreamReader logFile = new StreamReader(LogFilePath))
            {
                string line;
                while ((line = logFile.ReadLine()) != null)
                {
                    logItems.Add(LogFile.ParseLog(line));
                }
            }
            var logLessThanDate = logItems.Where(item => item.TimeOfChanges <= dateAndTime);
            foreach (var item in logLessThanDate)
            {
                switch (item.TypeOfChanges)
                {
                    case "Changed":
                        {
                            File.Delete(item.NewPathToFile);
                            string nameSourceFile = ($"{LogFile.DateFromLogToString(item.TimeOfChanges)}_{item.LogGuide}.txt");
                            string soursePath = Path.Combine(folderForCopyFiles, nameSourceFile);
                            File.Copy(soursePath, item.NewPathToFile);
                            break;
                        }
                    case "Created":
                        {
                            if (item.TypeOfObject.Equals("File"))
                            {
                                File.Create(item.NewPathToFile).Close();
                                break;
                            }
                            else
                            {
                                Directory.CreateDirectory(item.NewPathToFile);
                                break;
                            }
                        }
                    case "Deleted":
                        {
                            if (item.TypeOfObject.Equals("File"))
                            {
                                File.Delete(item.NewPathToFile);
                                break;
                            }
                            else
                            {
                                Directory.Delete(item.NewPathToFile, true);
                                break;
                            }
                        }
                    case "Renamed":
                        {
                            if (item.TypeOfObject.Equals("File"))
                            {
                                File.Delete(item.OldPathToFile);
                                File.Create(item.NewPathToFile).Close();
                                break;
                            }
                            else
                            {
                                Directory.Delete(item.OldPathToFile, true);
                                Directory.CreateDirectory(item.NewPathToFile);
                                break;
                            }
                        }
                    default:
                        break;
                }
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    if (!Directory.Exists(e.FullPath))
                    {
                        DateTime dateTimeOfChange = DateTime.Now;
                        string dateForLog = dateTimeOfChange.ToString("MM-dd-yyyy_HH-mm-ss");
                        string logGuid = Guid.NewGuid().ToString();
                        using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
                        {
                            logFile.WriteLine($"{dateForLog}|File|{e.ChangeType}|{e.FullPath}|{logGuid}");
                        }

                        string nameFile = ($"{dateForLog}_{logGuid}.txt");
                        string pathToCopy = Path.Combine(folderForCopyFiles, nameFile);
                        File.Copy(e.FullPath, pathToCopy);
                        flag = false;
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
            bool flag = true;
            while (flag)
            {
                try
                {
                    DateTime dateTimeOfChange = DateTime.Now;
                    string dateForLog = dateTimeOfChange.ToString("MM-dd-yyyy_HH-mm-ss");
                    if ((source as FileSystemWatcher).NotifyFilter.HasFlag(NotifyFilters.FileName))
                    {
                        using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
                        {
                            logFile.WriteLine($"{dateForLog}|File|{e.ChangeType}|{e.FullPath}|{Guid.NewGuid()}");
                        }
                    }
                    else
                    {
                        using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
                        {
                            logFile.WriteLine($"{dateForLog}|Folder|{e.ChangeType}|{e.FullPath}|{Guid.NewGuid()}");
                        }
                    }
                        flag = false;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            bool flag = true;
            while(flag)
            {
                try
                {
                    DateTime dateTimeOfChange = DateTime.Now;
                    string dateForLog = dateTimeOfChange.ToString("MM-dd-yyyy_HH-mm-ss");
                    if ((source as FileSystemWatcher).NotifyFilter.HasFlag(NotifyFilters.FileName))
                    {
                        using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
                        {
                            logFile.WriteLine($"{dateForLog}|File|{e.ChangeType}|{e.OldFullPath}|{e.FullPath}|{Guid.NewGuid()}");
                        }
                    }
                    else
                    {
                        using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
                        {
                            logFile.WriteLine($"{dateForLog}|Folder|{e.ChangeType}|{e.OldFullPath}|{e.FullPath}|{Guid.NewGuid()}");
                        }
                    }
                        flag = false;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
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