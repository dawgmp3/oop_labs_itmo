namespace Backups.Classes
{
    public class Backup
    {
        /*private string _name;
        private string _directory;

        public Backup(string name, string directory)
        {
            _name = name;
            _directory = directory;
        }

        public Backup CreateCopy(string name, string directory)
        {
            var copy = new Backup(name, directory);
            return copy;
        }*/
        private JobObject _file;

        public Backup(JobObject file)
        {
            _file = file;
        }
    }
}