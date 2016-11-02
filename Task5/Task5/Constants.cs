using System.IO;

namespace Task5
{
    public class Constants
    {
        public static string dateFormat = "MM-dd-yyyy_HH-mm-ss";
        public static int isFileFlag = 0;
        public static int isFolderFlag = 1;
        public static string utilityFolderKey = "utilityFolder";
        public static string folderForCopyFilesKey = "folderForCopyFiles";
        public static string trackingFolderPathKey = "trackingFolderPath";
        public static string trackingDirectoryName = "WatchedFolder";
        public static string LogFilePath { get; } = Path.Combine(SettingsFromConfig.ReadSetting(Constants.utilityFolderKey), "log.txt");
        public static string CopiedFolderPath { get; } = Path.Combine(SettingsFromConfig.ReadSetting(Constants.folderForCopyFilesKey), trackingDirectoryName);
        public static string TrackingFolderPath { get; } = SettingsFromConfig.ReadSetting(Constants.trackingFolderPathKey);
    }
}