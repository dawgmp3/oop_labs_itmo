using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using Backups.Classes;
using Ionic.Zip;

namespace Backups.Services
{
    public class Single : IAlgorithm
    {
        public List<Storage> CreateStorages(List<JobObject> jobObjects)
        {
            List<Storage> storages = new List<Storage>();
            var storage = new Storage();
            storage.JobObjects.AddRange(jobObjects);
            storages.Add(storage);
            return storages;
        }
    }
}