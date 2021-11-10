using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class ScheduleISU
    {
        private List<LessonGroup> _lessons;
        public ScheduleISU()
        {
            _lessons = new List<LessonGroup>();
        }

        public List<LessonGroup> GetSchedule()
        {
            return _lessons;
        }

        public void AddLesson(LessonGroup lesson)
        {
            _lessons.Add(lesson);
        }
    }
}