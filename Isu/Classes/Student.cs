using System;
using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        private static string _name;
        private static Group _group;
        private static int _id;
        public Student(string name, Group group, int id)
        {
            _name = name;
            _group = group;
            _id = id;
        }

        public static StudentBuilder ToBuild(StudentBuilder student)
        {
            student.WithName(_name);
            student.WithGroup(_group);
            student.WithId(_id);
            return student;
        }

        public Group GetStudentGroup()
        {
            return _group;
        }

        public string GetStudentName()
        {
            return _name;
        }

        public int GetStudentId()
        {
            return _id;
        }

        public class StudentBuilder
        {
            private string _name;
            private Group _group;
            private int _id;

            public StudentBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public StudentBuilder WithGroup(Group group)
            {
                _group = group;
                return this;
            }

            public StudentBuilder WithId(int id)
            {
                _id = id;
                return this;
            }

            public Student Build()
            {
                var student = new Student(_name, _group, _id);
                return student;
            }
        }
    }
}