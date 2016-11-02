using System.IO;

namespace Task5
{
    public interface IFolderLogger
    {
        void WriteCreateOrDeleteFolder(FileSystemEventArgs e, string dateForLog);

        void WriteRenameFolder(RenamedEventArgs e, string dateForLog);
    }
}