using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Isu.Classes;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuServices : IIsuService
    {
        private List<Group> Groups { get; } = new List<Group>();

        public Group AddGroup(string name)
        {
            if (name[0] != 'M' || name[1] != '3')
            {
                throw new IsuException("Wrong name");
            }

            var group = new Group(name);
            Groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (group.Students.Count >= 30)
                throw new IsuException("There is no more place. Add less students.");
            var stud = new Student(name);
            var listStudents = group.Students;
            listStudents.Add(stud);
            return stud;
        }

        public Student GetStudent(int id)
        {
            foreach (var group in Groups)
            {
                foreach (var studentId in group.Students)
                {
                    if (studentId.Id == id)
                    {
                        return studentId;
                    }
                }
            }

            throw new IsuException("Student with this id doesn't exist");
        }

        public Student FindStudent(string name)
        {
            foreach (var group in Groups)
            {
                foreach (var studentName in group.Students)
                {
                    var student = studentName.Name;
                    if (student != name)
                    {
                        throw new IsuException("Student with this name doesn't exist");
                    }
                    else
                    {
                        return studentName;
                    }
                }
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (Group group in Groups)
            {
                if (group.NName == groupName)
                {
                    return group.Students;
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var foundStudents = new List<Student>();
            foreach (Group group in Groups)
            {
                if (group.Name.CourseNumber == courseNumber)
                {
                    foreach (Student groupStudent in group.Students)
                    {
                        foundStudents.Add(groupStudent);
                    }
                }
            }

            return null;
        }

        public Group FindGroup(string groupName)
        {
            foreach (var group in Groups)
            {
                if (group.NName == groupName)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var group = new List<Group>();
            foreach (var gr in Groups)
            {
                if (gr.Name.CourseNumber == courseNumber)
                {
                    group.Add(gr);
                }
            }

            return group;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            foreach (var group in Groups)
            {
                foreach (var foundstudent in group.Students.ToList())
                {
                    if (foundstudent.Id == student.Id)
                    {
                        newGroup.Students.Add(student);
                        group.Students.Remove(student);
                    }
                }
            }
        }
    }
}