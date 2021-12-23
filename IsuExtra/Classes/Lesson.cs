using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Lesson
    {
        public Lesson(string teacher, int day, int numberOfLesson, int auditory)
        {
            Teacher = teacher;
            Day = day;
            NumberOfLesson = numberOfLesson;
            Auditory = auditory;
        }

        public int Auditory { get; set; }

        public int NumberOfLesson { get; set; }

        public int Day { get; set; }

        public string Teacher { get; set; }
    }
}