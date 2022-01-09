using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.Services
{
    public class BackupExtra : IBackupExtra
    {
        public void MergeFirst(RestorePoint oldPoint, RestorePoint newPoint)
        {
            List<Storage> oldStorages = oldPoint.GetStorages();
            List<Storage> newStorages = newPoint.GetStorages();
            int check = 0;
            foreach (var storage in oldStorages)
            {
                if (storage.GetJobObjects() != null)
                {
                    check = 1;
                }
            }

            foreach (var storage in newStorages)
            {
                if (storage.GetJobObjects() != null)
                {
                    check += 1;
                }
            }

            if (check == 2)
            {
                foreach (var storage in oldStorages)
                {
                    storage.JobObjects = null;
                }
            }
        }

        public void MergeSecond(RestorePoint oldPoint, RestorePoint newPoint)
        {
            List<Storage> oldStorages = oldPoint.GetStorages();
            List<Storage> newStorages = newPoint.GetStorages();
            int check = 0;
            foreach (var storage in oldStorages)
            {
                if (storage.GetJobObjects() != null)
                {
                    check = 1;
                }
            }

            foreach (var storage in newStorages)
            {
                if (storage.GetJobObjects() == null)
                {
                    check += 1;
                }
            }

            if (check == 2)
            {
                foreach (var oldStorage in oldStorages)
                {
                    foreach (var newStorage in newStorages)
                    {
                        newStorage.JobObjects = oldStorage.JobObjects;
                    }
                }
            }
        }

        public void MergeThird(RestorePoint oldPoint)
        {
            if (oldPoint.GetStorages().Count == 1)
            {
                oldPoint = null;
            }
        }

        public void RecoveryToOriginalLocation(RestorePoint point)
        {
            RestorePoint newPoint = point;
            newPoint.GetStorages();
        }
    }
}