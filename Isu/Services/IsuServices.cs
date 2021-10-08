using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Isu.Classes;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuServices : IIsuService
    {
        private List<Group> _groups = new List<Group>();
        private List<Student> _allstudents = new List<Student>();
        private List<string> _groupnames = new List<string> { "M3" };
        private int _maxCountOfStudent;

        public IsuServices(int max)
        {
            _maxCountOfStudent = max;
        }

        public Group AddGroup(string name)
        {
            bool permission = false;
            foreach (var namee in _groupnames)
            {
                if (name.Substring(0, 2) == namee)
                {
                    permission = true;
                }
            }

            if (permission == false)
            {
                throw new IsuException("Wrong name.");
            }

            var group = new Group(new GroupName(name));
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (_maxCountOfStudent <= group.GetCountOfStudents())
                throw new IsuException("There is no more place.");
            var stud = new Student(name, group);
            _allstudents.Add(stud);
            group.CountOfStudents();
            return stud;
        }

        public Student GetStudent(int id)
        {
            foreach (var studentId in _allstudents)
            {
                if (studentId.Id == id)
                {
                    return studentId;
                }
            }

            throw new IsuException("Student with this id doesn't exist");
        }

        public Student FindStudent(string name)
        {
            foreach (var student in _allstudents)
            {
                if (student.Name == name)
                {
                    return student;
                }
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            var students = new List<Student>();
            foreach (Student student in _allstudents)
            {
                if (student.Group.Name.ToString() == groupName)
                {
                    students.Add(student);
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentInCourse = new List<Student>();
            foreach (Student student in _allstudents)
            {
                if (student.Group.Name.CourseNumber == courseNumber)
                {
                    studentInCourse.Add(student);
                }

                return studentInCourse;
            }

            return null;
        }

        public Group FindGroup(string groupName)
        {
            foreach (var group in _groups)
            {
                if (group.Name.ToString() == groupName)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groupsCourse = new List<Group>();
            foreach (var group in _groups)
            {
                if (group.Name.CourseNumber == courseNumber)
                {
                    groupsCourse.Add(group);
                }
            }

            return groupsCourse;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.Group = newGroup;
        }
    }
}
