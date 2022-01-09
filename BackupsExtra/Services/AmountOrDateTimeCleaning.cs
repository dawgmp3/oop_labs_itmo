using System;
using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.Services
{
    public class AmountOrDateTimeCleaning : ICleaning
    {
        public List<RestorePoint> CleaningAlgorithm(List<RestorePoint> points, DateTime time, int limit)
        {
            RestorePoint lastPoint;
            if (points.Count > limit)
            {
                for (int i = 0; i < points.Count - limit; i++)
                {
                    lastPoint = points[points.Count - 1];
                    points.Remove(lastPoint);
                }

                return points;
            }

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