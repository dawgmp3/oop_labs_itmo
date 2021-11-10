using System;
using System.Collections.Generic;
using Isu.Classes;

namespace Isu.Services
{
    public interface IIsuService
    {
        Group AddGroup(string name);
        Student AddStudent(string name, Group group);

        Student GetStudent(Guid id);
        Student FindStudent(string name);
        List<Student> FindStudents(string groupName);
        List<Student> FindStudents(CourseNumber courseNumber);

        Group FindGroup(string groupName);
        List<Group> FindGroups(CourseNumber courseNumber);

        Student ChangeStudentGroup(Student student, Group newGroup);
    }
}