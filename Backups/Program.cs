using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Classes;
using Backups.Services;
using Ionic.Zip;
using ZipFile = Ionic.Zip.ZipFile;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            BackupJob backupJob = new BackupJob();

            IRepository repository = new LocalRepository(new DirectoryInfo(@"/Users/marinaburnaseva/Desktop/Directory11"));
            JobObject jobObject1 = new JobObject(new FileInfo(@"/Users/marinaburnaseva/Desktop/FileA"));
            JobObject jobObject2 = new JobObject(new FileInfo(@"/Users/marinaburnaseva/Desktop/FileB"));
            List<JobObject> jobObjects = new List<JobObject>() { jobObject1, jobObject2 };
            backupJob.AddListJobObjects(jobObjects);
            backupJob.LaunchBackup(repository, new Single());
        }
    }
}
