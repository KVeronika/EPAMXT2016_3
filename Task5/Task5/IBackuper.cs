using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public interface IBackuper
    {
        void BackupForChange(LogItem item);
        void BackupForCreate(LogItem item);
        void BackupForDelete(LogItem item);
        void BackupForRename(LogItem item);
    }
}
