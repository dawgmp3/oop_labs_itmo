using System;
using System.Collections.Generic;
using System.IO;
using Backups.Classes;
using Ionic.Zip;

namespace Backups.Services
{
    public class Split : IAlgorithm
    {
        public List<Storage> CreateStorages(List<JobObject> jobObjects)
        {
            var listOfStorages = new List<Storage>();
            foreach (var jobObject in jobObjects)
            {
                var storage = new Storage();
                storage.JobObjects.Add(jobObject);
                listOfStorages.Add(storage);
            }

            return listOfStorages;
        }
    }
}