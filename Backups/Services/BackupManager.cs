using System.Collections.Generic;
using System.IO;
using Backups.Classes;

namespace Backups.Services
{
    public class BackupManager : IBackupManager
    {
        private BackupJob _backupJob;
        public BackupManager(BackupJob backupJob)
        {
            _backupJob = backupJob;
        }

        public BackupJob GetBackupJob()
        {
            return _backupJob;
        }

        public void LaunchBackup(IRepository repository, IAlgorithm algorithm)
        {
            List<Storage> storages = repository.MakeBackup(_backupJob.GetListJobObjects(), algorithm);
            RestorePoint restorePoint = new RestorePoint(storages);
            _backupJob.AddPoint(restorePoint);
        }
    }
}