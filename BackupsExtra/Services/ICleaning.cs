using System;
using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.Services
{
    public interface ICleaning
    {
        List<RestorePoint> CleaningAlgorithm(List<RestorePoint> points, DateTime time, int limit);
    }
}