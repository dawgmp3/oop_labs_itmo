namespace Backups.Classes
{
    public class Backup
    {
        private JobObject _file;
        public Backup(JobObject file)
        {
            File = file;
        }

        public JobObject File { get; set; }
    }
}