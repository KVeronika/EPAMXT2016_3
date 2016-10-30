using System;
using System.Text;

namespace Task5
{
    internal class LogFile
    {
        public DateTime TimeOfChanges { get; set; }
        public string TypeOfChanges { get; set; }
        public string NewPathToFile { get; set; }
        public string OldPathToFile { get; set; }
        public string LogGuide { get; set; }
        public string TypeOfObject { get; set; }

        public LogFile(string dateAndTime, string typeOfObject, string typeOfChanges, string path, string logGuide)
        {
            this.TimeOfChanges = ParseDate(dateAndTime);
            this.TypeOfChanges = typeOfChanges;
            this.NewPathToFile = path;
            this.LogGuide = logGuide;
            this.TypeOfObject = typeOfObject;
        }

        public LogFile(string dateAndTime, string typeOfObject, string typeOfChanges, string oldPath, string newPath, string logGuide)
            : this(dateAndTime, typeOfObject, typeOfChanges, newPath, logGuide)
        {
            this.OldPathToFile = oldPath;
        }

        private static DateTime ParseDate(string dateAndTime)
        {
            string[] array = dateAndTime.Split('_');
            StringBuilder[] arr = new StringBuilder[2];
            for (int i = 0; i < array.Length; i++)
            {
                arr[i] = new StringBuilder(array[i]);
            }
            arr[0].Replace('-', '/');
            arr[1].Replace('-', ':');
            return DateTime.Parse(arr[0].ToString() + " " + arr[1].ToString());
        }

        public static LogFile ParseLog(string line)
        {
            string[] array = line.Split('|');
            if (array[1] != "Renamed")
            {
                return new LogFile(array[0], array[1], array[2], array[3], array[4]);
            }
            else
            {
                return new LogFile(array[0], array[1], array[2], array[3], array[4], array[5]);
            }
        }

        public static string DateFromLogToString(DateTime date)
        {
            return ($"{date.Month}-{date.Day}-{date.Year}_{date.Hour}-{date.Minute}-{date.Second}");
        }
    }
}