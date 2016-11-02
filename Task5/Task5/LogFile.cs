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
        public int TypeOfObject { get; set; }

        public LogFile(string dateAndTime, int typeOfObject, string typeOfChanges, string path, string logGuide)
        {
            this.TimeOfChanges = ParseDate(dateAndTime);
            this.TypeOfChanges = typeOfChanges;
            this.NewPathToFile = path;
            this.LogGuide = logGuide;
            this.TypeOfObject = typeOfObject;
        }

        public LogFile(string dateAndTime, int typeOfObject, string typeOfChanges, string oldPath, string newPath, string logGuide)
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
            return DateTime.Parse($"{arr[0].ToString()} {arr[1].ToString()}");
        }

        public static LogFile ParseLog(string line)
        {
            string[] array = line.Split('|');
            string dateAndTime = array[0];
            int typeOfObject = int.Parse(array[1]);
            string typeOfChanges = array[2];
            if (typeOfChanges != "Renamed")
            {
                string path = array[3];
                string logGuide = array[4];
                return new LogFile(dateAndTime, typeOfObject, typeOfChanges, path, logGuide);
            }
            else
            {
                string oldPath = array[3];
                string newPath = array[4];
                string logGuide = array[5];
                return new LogFile(dateAndTime, typeOfObject, typeOfChanges, oldPath, newPath, logGuide);
            }
        }

        public static string DateFromLogToString(DateTime date)
        {
            return date.ToString(Constants.dateFormat);
        }
    }
}