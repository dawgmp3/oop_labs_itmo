using System.IO;

namespace Backups.Classes
{
    public class JobObject
    {
        public JobObject(FileInfo name)
        {
            File = name;
        }

        public FileInfo File { get; }

        public string GetFullPath()
        {
            return $@"{File.DirectoryName}/{File.Name}";
        }
    }
}