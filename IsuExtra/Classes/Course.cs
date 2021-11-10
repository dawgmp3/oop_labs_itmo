using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Course
    {
        private static string _name;
        private static string _faculty;
        private static Flow _flow;
        public Course(string name, string faculty, Flow flow)
        {
            _name = name;
            _faculty = faculty;
            Students = new List<ExtraStudent>();
            _flow = flow;
        }

        public List<ExtraStudent> Students { get; }

        public string GetName() { return _name; }
        public string GetFaculty() { return _faculty; }

        public Flow GetFlow()
        {
            return _flow;
        }

        public void SetFlow(Flow flow)
        {
            _flow = flow;
        }

        public void AddStudent(ExtraStudent student)
        {
            Students.Add(student);
        }

        public int CountStudents()
        {
            int count = Students.Count;
            return count;
        }

        public int GetAmountOfStudents()
        {
            int a = Students.Count;
            return a;
        }
    }
}