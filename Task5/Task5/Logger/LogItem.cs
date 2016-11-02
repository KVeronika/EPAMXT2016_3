using System;
using System.Globalization;

namespace Task5
{
    public class LogItem
    {
        public DateTime TimeOfChanges { get; set; }
        public string TypeOfChanges { get; set; }
        public string NewPathToFile { get; set; }
        public string OldPathToFile { get; set; }
        public string LogGuide { get; set; }
        public int TypeOfObject { get; set; }

        private LogItem(string dateAndTime, int typeOfObject, string typeOfChanges, string path, string logGuide)
        {
            this.TimeOfChanges = ParseDate(dateAndTime);
            this.TypeOfChanges = typeOfChanges;
            this.NewPathToFile = path;
            this.LogGuide = logGuide;
            this.TypeOfObject = typeOfObject;
        }

        private LogItem(string dateAndTime, int typeOfObject, string typeOfChanges, string oldPath, string newPath, string logGuide)
            : this(dateAndTime, typeOfObject, typeOfChanges, newPath, logGuide)
        {
            this.OldPathToFile = oldPath;
        }

        private static DateTime ParseDate(string dateAndTime)
        {
            return DateTime.ParseExact(dateAndTime, Constants.dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        public static LogItem ParseLogItem(string line)
        {
            string[] array = line.Split('|');
            string dateAndTime = array[0];
            int typeOfObject = int.Parse(array[1]);
            string typeOfChanges = array[2];
            if (typeOfChanges != "Renamed")
            {
                string path = array[3];
                string logGuide = array[4];
                return new LogItem(dateAndTime, typeOfObject, typeOfChanges, path, logGuide);
            }
            else
            {
                string oldPath = array[3];
                string newPath = array[4];
                string logGuide = array[5];
                return new LogItem(dateAndTime, typeOfObject, typeOfChanges, oldPath, newPath, logGuide);
            }
        }

        public static string DateFromLogToString(DateTime date)
        {
            return date.ToString(Constants.dateFormat);
        }
    }
}