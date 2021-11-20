using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class ScheduleOGNP
    {
        private List<Lesson> _lessons;
        public ScheduleOGNP()
        {
            _lessons = new List<Lesson>();
        }

        public List<Lesson> GetSchedule()
        {
            return _lessons;
        }

        public List<Lesson> AddLesson(Lesson lesson)
        {
            _lessons.Add(lesson);
            return _lessons;
        }
    }
}