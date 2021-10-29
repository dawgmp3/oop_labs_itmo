using System;
using System.Collections.Generic;
using Isu.Classes;
using IsuExtra.Classes;

namespace Isu.Services
{
    public interface IOGNP
    {
        Course AddCourse(string name, string faculty, int amount, Flow flow);
        Student AddStudent(string name, GroupISU group, int id);
        Flow AddFlow(string name, GroupOGNP group1, GroupOGNP group2, GroupOGNP group3);

        LessonOGNP AddLessonToFlow(Flow flow, Course course, string teacher, string day, GroupOGNP group, int hour, int minutes, int auditory);

        LessonGroup AddLessonToGroup(GroupISU group, Course course, string teacher, string day, int hour, int minutes, int auditory);
        bool PermissionForSigning(GroupOGNP group, ScheduleISU studentsSchedule);
        Student AddStudentToCourse(Student student, Course course);
        Flow GetFlows(Course course);
        List<Student> GetStudents(Course course, string name);
        List<Student> GetNotSignedStudents();
        Student RemoveStudentFromOgnp(Student student, Course course);
    }
}