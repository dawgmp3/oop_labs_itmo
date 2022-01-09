using System;
using System.Collections.Generic;
using Backups.Classes;

namespace BackupsExtra.Services
{
    public class AmountAndDateTimeCleaning : ICleaning
    {
        public List<RestorePoint> CleaningAlgorithm(List<RestorePoint> points, DateTime time, int limit)
        {
            List<RestorePoint> pointsToDeleteFromFirst = new List<RestorePoint>();
            List<RestorePoint> pointsToDeleteFromSecond = new List<RestorePoint>();
            foreach (var point in points)
            {
                if (points.Count > limit)
                {
                    for (int i = 0; i < points.Count - limit; i++)
                    {
                        pointsToDeleteFromFirst.Add(point);
                    }
                }
            }

            foreach (var point in points)
            {
                if (point.GetDateTime() < time)
                {
                    pointsToDeleteFromSecond.Add(point);
                }
            }

            foreach (var point in pointsToDeleteFromFirst)
            {
                if (pointsToDeleteFromSecond.Contains(point))
                {
                    points.Remove(point);
                }
            }

            return points;
        }
    }
}