using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class ScheduleISU
    {
        private Student _student;
        private List<LessonGroup> _lessons;
        public ScheduleISU(Student student)
        {
            _student = student;
            Group group = student.GetStudentGroup();
            _lessons = new List<LessonGroup>();
        }

        public List<LessonGroup> GetSchedule()
        {
            return _lessons;
        }
    }
}