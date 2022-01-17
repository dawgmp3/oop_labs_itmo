using System;
using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.Services
{
    public class AmountOfPointsCleaning : ICleaning
    {
        public List<RestorePoint> CleaningAlgorithm(List<RestorePoint> points, DateTime time, int limit)
        {
            RestorePoint point;
            if (points.Count > limit)
            {
                for (int i = 0; i < points.Count - limit; i++)
                {
                    point = points[points.Count - 1];
                    points.Remove(point);
                }
            }

            return points;
        }
    }
}