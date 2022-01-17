namespace Backups.Classes
{
    public class Backup
    {
        public Backup(JobObject file)
        {
            File = file;
        }

        public JobObject File { get; set; }
    }
}