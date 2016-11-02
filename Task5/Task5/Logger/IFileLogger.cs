using System.IO;

namespace Task5
{
    public interface IFileLogger
    {
        void WriteChangeOfFile(FileSystemEventArgs e, string dateForLog, string logGuid);

        void WriteCreateOrDeleteFile(FileSystemEventArgs e, string dateForLog);

        void WriteRenameFile(RenamedEventArgs e, string dateForLog);
    }
}