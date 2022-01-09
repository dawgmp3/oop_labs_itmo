using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using BackupsExtra.Services;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupTests
    {
        private IBackupExtra _backupExtra;

        [SetUp]
        public void Setup()
        {
            _backupExtra = new BackupExtra();
        }
        [Test]
        public void MergeFirst()
        {
            FileInfo file = new FileInfo("dfghj");
            JobObject jobObject = new JobObject(file);
            Storage storage = new Storage();
            storage.JobObjects.Add(jobObject);
            List<Storage> storages1 = new List<Storage>();
            storages1.Add(storage);
            RestorePoint r1 = new RestorePoint(storages1);
            
            FileInfo file2 = new FileInfo("dfghj");
            JobObject jobObject2 = new JobObject(file2);
            Storage storage2 = new Storage();
            storage2.JobObjects.Add(jobObject2);
            List<Storage> storages2 = new List<Storage>();
            storages2.Add(storage2);
            RestorePoint r2 = new RestorePoint(storages2);
            Assert.AreEqual(true, _backupExtra.MergeFirst(r1, r2));
        }
        [Test]
        public void MergeSecond()
        {
            FileInfo file = new FileInfo("dfghj");
            JobObject jobObject = new JobObject(file);
            Storage storage = new Storage();
            storage.JobObjects.Add(jobObject);
            List<Storage> storages1 = new List<Storage>();
            storages1.Add(storage);
            RestorePoint r1 = new RestorePoint(storages1);
            
            List<Storage> storages2 = new List<Storage>();
            Storage storage2 = new Storage();
            storage2.JobObjects = null;
            storages2.Add(storage2);
            RestorePoint r2 = new RestorePoint(storages2);
            Assert.AreEqual(true, _backupExtra.MergeSecond(r1, r2));
        }
        [Test]
        public void MergeThird()
        {
            FileInfo file = new FileInfo("dfghj");
            JobObject jobObject = new JobObject(file);
            Storage storage = new Storage();
            storage.JobObjects.Add(jobObject);
            List<Storage> storages1 = new List<Storage>();
            storages1.Add(storage);
            RestorePoint r1 = new RestorePoint(storages1);
            Assert.AreEqual(true, _backupExtra.MergeThird(r1));
        }
    }
    
}