using Backups.Classes;

namespace BackupsExtra.Services
{
    public interface IBackupExtra
    {
        void MergeFirst(RestorePoint oldPoint, RestorePoint newPoint);
        void MergeSecond(RestorePoint oldPoint, RestorePoint newPoint);
        void MergeThird(RestorePoint oldPoint);
        void RecoveryToOriginalLocation(RestorePoint point);
    }
}