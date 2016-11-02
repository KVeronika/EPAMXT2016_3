using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class Backuper : IBackuper
    {
        public void BackupForChange(LogItem item)
        {
            string nameSourceFile = ($"{LogItem.DateFromLogToString(item.TimeOfChanges)}_{item.LogGuide}.txt");
            string soursePath = Path.Combine(SettingsFromConfig.ReadSetting(Constants.folderForCopyFilesKey), nameSourceFile);
            File.Copy(soursePath, item.NewPathToFile, true);
        }

        public void BackupForCreate(LogItem item)
        {
            if (item.TypeOfObject == Constants.isFileFlag)
            {
                File.Create(item.NewPathToFile).Close();
            }
            else
            {
                Directory.CreateDirectory(item.NewPathToFile);
            }
        }

        public void BackupForDelete(LogItem item)
        {
            if (item.TypeOfObject == Constants.isFileFlag)
            {
                File.Delete(item.NewPathToFile);
            }
            else
            {
                Directory.Delete(item.NewPathToFile, true);
            }
        }

        public void BackupForRename(LogItem item)
        {
            if (item.TypeOfObject == Constants.isFileFlag)
            {
                File.Delete(item.OldPathToFile);
                File.Create(item.NewPathToFile).Close();
            }
            else
            {
                Directory.Delete(item.OldPathToFile, true);
                Directory.CreateDirectory(item.NewPathToFile);
            }
        }
    }
}
