using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class GroupOGNP
    {
        private string _name;
        private int _maxCount;
        public GroupOGNP(string name, int max)
        {
            _name = name;
            _maxCount = max;
            Students = new List<Student>();
            Lessons = new List<LessonOGNP>();
        }

        public List<LessonOGNP> Lessons { get; }

        public List<Student> Students { get; }

        public string GetName()
        {
            return _name;
        }

        public int GetMaxAmount()
        {
            return _maxCount;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public int CountOfStudents()
        {
            int a = Students.Count;
            return a;
        }
    }
}