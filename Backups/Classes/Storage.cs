using System;
using System.Collections.Generic;

namespace Backups.Classes
{
    public class Storage
    {
        public Storage()
        {
            Id = Guid.NewGuid();
            JobObjects = new List<JobObject>();
        }

        public Guid Id { get; }
        public List<JobObject> JobObjects { get; }

        public List<JobObject> GetFiles()
        {
            return JobObjects;
        }

        public void AddFile(JobObject jobObject)
        {
            JobObjects.Add(jobObject);
        }
    }
}