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
            var group = new Group(new GroupName(name));
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (_maxCountOfStudent <= group.GetCountOfStudents())
                throw new IsuException("There is no more place.");
            var student = new Student(name, group);
            _allstudents.Add(student);
            group.CountOfStudents();
            return student;
        }

        public Student GetStudent(int id)
        {
            foreach (var student in _allstudents.Where(student => student.Id1 == id))
            {
                return student;
            }

            throw new IsuException("Student with this id doesn't exist");
        }

        public Student FindStudent(string name)
        {
            return _allstudents.FirstOrDefault(student => student.Name == name);
        }

        public List<Student> FindStudents(string groupName)
        {
            var students = _allstudents.Where(student => student.Group.Name.ToString() == groupName).ToList();

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
            return _groups.FirstOrDefault(@group => @group.Name.ToString() == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.Where(@group => @group.Name.CourseNumber == courseNumber).ToList();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.Group.MinusCount();
            student.Group = newGroup;
            student.Group.CountOfStudents();
        }
    }
}
