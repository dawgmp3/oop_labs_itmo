using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using Backups.Services;
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
    }
}