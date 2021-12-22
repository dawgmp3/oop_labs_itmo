using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Backups.Classes;

namespace BackupsExtra.Classes
{
    public class ConfigFile
    {
        private List<BackupJob> _backupJobs;
        public ConfigFile()
        {
            _backupJobs = new List<BackupJob>();
        }

        public void Saving(BackupJob backupJob)
        {
        }
    }
}