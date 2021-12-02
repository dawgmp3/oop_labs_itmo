using Backups.Classes;

namespace Backups.Services
{
    public interface IBackupManager
    {
        BackupJob GetBackupJob();
        void LaunchBackup(IRepository repository, IAlgorithm algorithm);
    }
}