using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Lesson
    {
        private string _teacher;
        private int _day;
        private int _numberOfLesson;
        private int _auditory;
        public Lesson(string teacher, int day, int numberOfLesson, int auditory)
        {
            _teacher = teacher;
            _day = day;
            _numberOfLesson = numberOfLesson;
            _auditory = auditory;
        }

        public string GetTeacher()
        {
            return _teacher;
        }

        public int GetDay()
        {
            return _day;
        }

        public int GetNumberOfLesson()
        {
            return _numberOfLesson;
        }

        public int GetAuditory()
        {
            return _auditory;
        }
    }
}