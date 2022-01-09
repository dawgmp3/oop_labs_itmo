using Backups.Classes;

namespace BackupsExtra.Services
{
    public interface IBackupExtra
    {
        bool MergeFirst(RestorePoint oldPoint, RestorePoint newPoint);
        bool MergeSecond(RestorePoint oldPoint, RestorePoint newPoint);
        bool MergeThird(RestorePoint oldPoint);
    }
}