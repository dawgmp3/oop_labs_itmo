using System.Collections.Generic;
using Backups.Services;

namespace Backups.Classes
{
    public class BackupJob
    {
        public BackupJob()
        {
            RestorePoints = new List<RestorePoint>();
            JobObjects = new List<JobObject>();
        }

        public List<JobObject> JobObjects { get; set; }

        public List<RestorePoint> RestorePoints { get; set; }

        public void AddPoint(RestorePoint point)
        {
            RestorePoints.Add(point);
        }

        public void DeletePoint(RestorePoint point)
        {
            RestorePoints.Remove(point);
        }

        public void AddJobObject(JobObject jobObject)
        {
            JobObjects.Add(jobObject);
        }

        public void AddListJobObjects(List<JobObject> jobObjects)
        {
            JobObjects.AddRange(jobObjects);
        }

        public void DeleteJobObject(JobObject jobObject)
        {
            JobObjects.Remove(jobObject);
        }

        public int GetNumberOfStorages()
        {
            int check = 0;
            foreach (var restorePoint in RestorePoints)
            {
                check += restorePoint.GetStorages().Count;
            }

            return check;
        }

        public void LaunchBackup(IRepository repository, IAlgorithm algorithm)
        {
            List<Storage> storages = repository.MakeBackup(JobObjects, algorithm);
            RestorePoint restorePoint = new RestorePoint(storages);
            RestorePoints.Add(restorePoint);
        }
    }
}