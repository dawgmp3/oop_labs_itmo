using System;
using System.Collections.Generic;
using Isu.Classes;
using IsuExtra.Classes;

namespace Isu.Services
{
    public interface IOGNP
    {
        Course AddCourse(string name, string faculty, Flow flow);
        Flow AddGroupsToFlow(Flow flow, GroupOGNP group1, GroupOGNP group2, GroupOGNP group3);

        LessonOGNP AddLessonToFlow(string teacher, int day, GroupOGNP group, int time, int auditory);

        LessonGroup AddLessonToGroup(GroupISU group, string teacher, int day, int time, int auditory);
        bool PermissionForSigning(GroupOGNP group, List<LessonGroup> lessons1);
        ExtraStudent AddStudentToCourse(ExtraStudent student, Course course);
        Flow GetFlows(Course course);
        List<ExtraStudent> GetStudentsOgnpGroup(GroupOGNP group);
        List<ExtraStudent> GetStudentsFromCourse(Course course, string name);
        List<ExtraStudent> GetNotSignedStudents();
        Student RemoveStudentFromOgnp(ExtraStudent student, Course course);
    }
}