using System.Collections.Generic;

namespace Backups.Classes
{
    public class BackupJob
    {
        private List<RestorePoint> _restorePoints;
        private List<JobObject> _jobObjects;
        public BackupJob()
        {
            _restorePoints = new List<RestorePoint>();
            _jobObjects = new List<JobObject>();
        }

        public void AddPoint(RestorePoint point)
        {
            _restorePoints.Add(point);
        }

        public void DeletePoint(RestorePoint point)
        {
            _restorePoints.Remove(point);
        }

        public List<RestorePoint> GetRestorePoints()
        {
            return _restorePoints;
        }

        public void AddJobObject(JobObject jobObject)
        {
            _jobObjects.Add(jobObject);
        }

        public void AddListJobObjects(List<JobObject> jobObjects)
        {
            _jobObjects.AddRange(jobObjects);
        }

        public void DeleteJobObject(JobObject jobObject)
        {
            _jobObjects.Remove(jobObject);
        }

        public List<JobObject> GetListJobObjects()
        {
            return _jobObjects;
        }

        public int GetNumberOfStorages()
        {
            int check = 0;
            foreach (var restorePoint in _restorePoints)
            {
                check += restorePoint.GetStorages().Count;
            }

            return check;
        }
    }
}