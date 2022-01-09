using System.Collections.Generic;
using System.IO;
using Backups.Classes;

namespace Backups.Services
{
    public interface IRepository
    {
        List<Storage> MakeBackup(List<JobObject> jobObjects, IAlgorithm algorithm);
    }
}