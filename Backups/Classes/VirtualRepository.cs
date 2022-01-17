using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.Services;
using Ionic.Zip;

namespace Backups.Classes
{
    public class VirtualRepository : IRepository
    {
        public VirtualRepository(DirectoryInfo directory)
        {
            Directory = directory;
        }

        public DirectoryInfo Directory { get; set; }

        public List<Storage> MakeBackup(List<JobObject> jobObjects, IAlgorithm algorithm)
        {
            List<Storage> storages = algorithm.CreateStorages(jobObjects);
            int i = 1;
            string newPath;
            foreach (var storage in storages)
            {
                foreach (var jobObject in storage.JobObjects.ToList())
                {
                    newPath = $@"{Directory.FullName}/{jobObject.File.Name}{"_"}{i}.zip";
                    i++;
                    JobObject newJobObject = new JobObject(new FileInfo(newPath));
                    storage.JobObjects.Add(newJobObject);
                }
            }

            return storages;
        }
    }
}