using System;
using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.Services
{
    public class SecondCleaning : ICleaning
    {
        public List<RestorePoint> CleaningAlgorithm(List<RestorePoint> points, DateTime time, int limit)
        {
            foreach (var point in points)
            {
                if (point.GetDateTime() < time)
                {
                    points.Remove(point);
                }
            }

            return points;
        }
    }
}