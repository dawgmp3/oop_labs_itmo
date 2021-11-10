using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class ScheduleOGNP
    {
        private List<LessonOGNP> _lessons;
        public ScheduleOGNP()
        {
            _lessons = new List<LessonOGNP>();
        }

        public List<LessonOGNP> GetSchedule()
        {
            return _lessons;
        }

        public List<LessonOGNP> AddLesson(LessonOGNP lesson)
        {
            _lessons.Add(lesson);
            return _lessons;
        }
    }
}