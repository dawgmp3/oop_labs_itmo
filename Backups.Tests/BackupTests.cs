using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using Backups.Services;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTests
    {
        private IBackupManager _backupManager;
        private BackupJob _backupJob;

        [SetUp]
        public void Setup()
        {
            _backupJob = new BackupJob();
            _backupManager = new BackupManager(_backupJob);
        }

        [Test]
        public void TwoPointThreeStorage()
        {
            IRepository repository = new VirtualRepository(new DirectoryInfo(@"../../../Directory1337"));
            JobObject jobObject1 = new JobObject(new FileInfo(@"../../../Files/FileA"));
            JobObject jobObject2 = new JobObject(new FileInfo(@"../../../Files/FileB"));
            List<JobObject> jobObjects = new List<JobObject>() {jobObject1, jobObject2};
            _backupJob.AddListJobObjects(jobObjects);
            _backupManager.LaunchBackup(repository, new Split());
            _backupJob.DeleteJobObject(jobObject1);
            _backupManager.LaunchBackup(repository, new Split());
            Assert.AreEqual(2, _backupJob.GetRestorePoints().Count);
            Assert.AreEqual(3, _backupJob.GetNumberOfStorages());
        }
    }
}