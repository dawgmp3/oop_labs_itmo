using System;
using System.Collections.Generic;
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

        public bool NameOfGroup(string name)
        {
            var groupname = new GroupName(name);
            bool rightname = false;
            foreach (var namee in _groupnames)
            {
                if (name.Substring(0, 2) == namee)
                {
                    rightname = true;
                }
            }

            if (rightname == false)
            {
                return false;
            }

            if (groupname.CourseNumber >= (CourseNumber)1 && groupname.CourseNumber <= (CourseNumber)4)
            {
                if (groupname.GroupNumber >= 0 && groupname.GroupNumber <= 11)
                {
                    return true;
                }
            }

            return false;
        }

        public Group AddGroup(string name)
        {
            bool namegroup = NameOfGroup(name);
            if (!namegroup) throw new IsuException("Wrong name.");
            var group = new Group(new GroupName(name), 30);
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (_maxCountOfStudent < group.GetAmount())
                throw new IsuException("There is no more place.");
            Student.StudentBuilder studentbuild = new Student.StudentBuilder();
            studentbuild.WithName(name);
            studentbuild.WithGroup(group);
            studentbuild.WithId(Id());
            Student student = studentbuild.Build();
            _allstudents.Add(student);
            group.PlusStudent();
            return student;
        }

        public Student GetStudent(Guid id)
        {
            foreach (var student in _allstudents.Where(student => student.GetStudentId() == id))
            {
                return student;
            }

            throw new IsuException("Student with this id doesn't exist");
        }

        public Student FindStudent(string name)
        {
            return _allstudents.FirstOrDefault(student => student.GetStudentName() == name);
        }

        public List<Student> FindStudents(string groupName)
        {
            var students = _allstudents.Where(student => student.GetStudentGroup().GetName().ToString() == groupName).ToList();

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentInCourse = new List<Student>();
            foreach (Student student in _allstudents)
            {
                if (student.GetStudentGroup().GetName().CourseNumber == courseNumber)
                {
                    studentInCourse.Add(student);
                }

                return studentInCourse;
            }

            return null;
        }

        public Group FindGroup(string groupName)
        {
            return _groups.FirstOrDefault(group => group.GetName().ToString() == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.Where(group => group.GetName().CourseNumber == courseNumber).ToList();
        }

        public Student ChangeStudentGroup(Student student, Group newGroup)
        {
            var builder = new Student.StudentBuilder();
            Student.StudentBuilder q = Student.ToBuild(builder);
            q.WithName(student.GetStudentName());
            q.WithGroup(newGroup);
            q.WithId(student.GetStudentId());
            Student changedStudent = q.Build();
            return changedStudent;
        }

        private static Guid Id()
        {
            var id = Guid.NewGuid();
            return id;
        }
    }
}
