using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Course
    {
        private static string _name;
        private static string _faculty;
        private static int _maxAmount;
        private static Flow _flow;
        public Course(string name, string faculty, int maxAmount, Flow flow)
        {
            _name = name;
            _faculty = faculty;
            _maxAmount = maxAmount;
            Students = new List<Student>();
            _flow = flow;
        }

        public List<Student> Students { get; }
        public static CourseBuilder ToBuild(CourseBuilder a)
        {
            a.WithName(_name);
            a.WithFaculty(_faculty);
            a.WithMaxAmount(_maxAmount);
            a.WithFlow(_flow);
            return a;
        }

        public string GetName() { return _name; }
        public string GetFaculty() { return _faculty; }
        public int GetMaxAmount() { return _maxAmount; }

        public Flow GetFlow()
        {
            return _flow;
        }

        public void AddStudent(Student student)
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

        public class CourseBuilder
        {
            private string _name;
            private string _faculty;
            private int _maxAmount;
            private Flow _flow;

            public CourseBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public CourseBuilder WithFaculty(string faculty)
            {
                _faculty = faculty;
                return this;
            }

            public CourseBuilder WithMaxAmount(int max)
            {
                _maxAmount = max;
                return this;
            }

            public CourseBuilder WithFlow(Flow flow)
            {
                _flow = flow;
                return this;
            }

            public Course Build()
            {
                var course = new Course(_name, _faculty, _maxAmount, _flow);
                return course;
            }
        }
    }
}