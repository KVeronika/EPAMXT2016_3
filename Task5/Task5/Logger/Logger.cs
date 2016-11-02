using System;
using System.Collections.Generic;
using System.IO;

namespace Task5
{
    public class Logger : IFileLogger, IFolderLogger
    {
        public void WriteChangeOfFile(FileSystemEventArgs e, string dateForLog, string logGuid)
        {
            using (StreamWriter logFile = new StreamWriter(Constants.LogFilePath, true))
            {
                logFile.WriteLine($"{dateForLog}|0|{e.ChangeType}|{e.FullPath}|{logGuid}");
            }
        }

        public void WriteCreateOrDeleteFolder(FileSystemEventArgs e, string dateForLog)
        {
            using (StreamWriter logFile = new StreamWriter(Constants.LogFilePath, true))
            {
                logFile.WriteLine($"{dateForLog}|1|{e.ChangeType}|{e.FullPath}|{Guid.NewGuid()}");
            }
        }

        public void WriteCreateOrDeleteFile(FileSystemEventArgs e, string dateForLog)
        {
            using (StreamWriter logFile = new StreamWriter(Constants.LogFilePath, true))
            {
                logFile.WriteLine($"{dateForLog}|0|{e.ChangeType}|{e.FullPath}|{Guid.NewGuid()}");
            }
        }

        public void WriteRenameFolder(RenamedEventArgs e, string dateForLog)
        {
            using (StreamWriter logFile = new StreamWriter(Constants.LogFilePath, true))
            {
                logFile.WriteLine($"{dateForLog}|1|{e.ChangeType}|{e.OldFullPath}|{e.FullPath}|{Guid.NewGuid()}");
            }
        }

        public void WriteRenameFile(RenamedEventArgs e, string dateForLog)
        {
            using (StreamWriter logFile = new StreamWriter(Constants.LogFilePath, true))
            {
                logFile.WriteLine($"{dateForLog}|0|{e.ChangeType}|{e.OldFullPath}|{e.FullPath}|{Guid.NewGuid()}");
            }
        }

        public static List<LogItem> ParseLogFile()
        {
            List<LogItem> logItems = new List<LogItem>();
            using (StreamReader logFile = new StreamReader(Constants.LogFilePath))
            {
                string line;
                while ((line = logFile.ReadLine()) != null)
                {
                    logItems.Add(LogItem.ParseLogItem(line));
                }
            }
            return logItems;
        }
    }
}