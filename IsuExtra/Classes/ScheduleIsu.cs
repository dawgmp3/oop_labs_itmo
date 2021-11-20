using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class ScheduleISU
    {
        private List<Lesson> _lessons;
        public ScheduleISU()
        {
            _lessons = new List<Lesson>();
        }

        public List<Lesson> GetSchedule()
        {
            return _lessons;
        }

        public void AddLesson(Lesson lesson)
        {
            _lessons.Add(lesson);
        }
    }
}