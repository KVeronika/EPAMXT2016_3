using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task5
{
    public class BackupSystem
    {
        public static int countOfChangeEvent = 0;
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
            FileSystemWatcher watcher = new FileSystemWatcher(path, "*.txt");
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.IncludeSubdirectories = true;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreateOrDelete);
            watcher.Deleted += new FileSystemEventHandler(OnCreateOrDelete);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
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
                            File.Create(item.NewPathToFile).Close();
                            break;
                        }
                    case "Deleted":
                        {
                            File.Delete(item.NewPathToFile);
                            break;
                        }
                    case "Renamed":
                        {
                            File.Delete(item.OldPathToFile);
                            File.Create(item.NewPathToFile).Close();
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (!(source is Directory))
            {
                countOfChangeEvent++;
                if (countOfChangeEvent % 2 == 0)
                {
                    DateTime dateTimeOfChange = DateTime.Now;
                    string dateForLog = ($"{dateTimeOfChange.Month}-{dateTimeOfChange.Day}-{dateTimeOfChange.Year}_{dateTimeOfChange.Hour}-{dateTimeOfChange.Minute}-{dateTimeOfChange.Second}");
                    string logGuid = Guid.NewGuid().ToString();
                    using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
                    {
                        logFile.WriteLine($"{dateForLog}|{e.ChangeType}|{e.FullPath}|{logGuid}");
                    }

                    string nameFile = ($"{dateForLog}_{logGuid}.txt");
                    string pathToCopy = Path.Combine(folderForCopyFiles, nameFile);
                    File.Copy(e.FullPath, pathToCopy);
                }
            }
            else
            {
                return;
            }
        }

        private static void OnCreateOrDelete(object source, FileSystemEventArgs e)
        {
            using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
            {
                DateTime dateTimeOfChange = DateTime.Now;
                string dateForLog = ($"{dateTimeOfChange.Month}-{dateTimeOfChange.Day}-{dateTimeOfChange.Year}_{dateTimeOfChange.Hour}-{dateTimeOfChange.Minute}-{dateTimeOfChange.Second}");
                logFile.WriteLine($"{dateForLog}|{e.ChangeType}|{e.FullPath}|{Guid.NewGuid()}");
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            using (StreamWriter logFile = new StreamWriter(LogFilePath, true))
            {
                DateTime dateTimeOfChange = DateTime.Now;
                string dateForLog = ($"{dateTimeOfChange.Month}-{dateTimeOfChange.Day}-{dateTimeOfChange.Year}_{dateTimeOfChange.Hour}-{dateTimeOfChange.Minute}-{dateTimeOfChange.Second}");
                logFile.WriteLine($"{dateForLog}|{e.ChangeType}|{e.OldFullPath}|{e.FullPath}|{Guid.NewGuid()}");
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