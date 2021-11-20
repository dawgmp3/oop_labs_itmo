using System;
using System.Collections.Generic;
using Isu.Classes;
using IsuExtra.Classes;

namespace Isu.Services
{
    public interface IOgnp
    {
        Course AddCourse(string name, string faculty, Flow flow);
        Flow AddGroupToFlow(Flow flow, GroupOGNP group);

        Lesson AddLessonToFlow(string teacher, int day, GroupOGNP group, int numberOfLesson, int auditory);

        Lesson AddLessonToGroup(GroupISU group, string teacher, int day, int numberOfLesson, int auditory);
        GroupOGNP PermissionForSigning(GroupOGNP group, List<Lesson> lessons1);
        ExtraStudent AddStudentToCourse(ExtraStudent student, Course course);
        Flow GetFlows(Course course);
        List<ExtraStudent> GetStudentsOgnpGroup(GroupOGNP group);
        List<ExtraStudent> GetStudentsFromCourse(Course course, string name);
        List<ExtraStudent> GetNotSignedStudents();
        ExtraStudent RemoveStudentFromOgnp(ExtraStudent student, Course course);
    }
}