using System;
using System.Collections.Generic;
using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Classes;

namespace IsuExtra.Services
{
    public class Ognp : IOGNP
    {
        private List<Course> _allCourses = new List<Course>();
        private List<ExtraStudent> _allStudent = new List<ExtraStudent>();
        private List<Student> _signedStudents = new List<Student>();

        public Course AddCourse(string name, string faculty, Flow flow)
        {
            foreach (Course courseName in _allCourses)
            {
                if (name == courseName.GetName())
                {
                    throw new IsuExtraException("Course already exists");
                }
            }

            Course newCourse = new Course(name, faculty, flow);
            _allCourses.Add(newCourse);
            return newCourse;
        }

        public Flow AddGroupsToFlow(Flow flow, GroupOGNP group1, GroupOGNP group2, GroupOGNP group3)
        {
            flow.Groups.Add(group1);
            flow.Groups.Add(group2);
            flow.Groups.Add(group3);
            return flow;
        }

        public LessonOGNP AddLessonToFlow(string teacher, int day, GroupOGNP group, int time, int auditory)
        {
            if (time <= 8 && day <= 7)
            {
                LessonOGNP lesson = new LessonOGNP(teacher, day, group, time, auditory);
                ScheduleOGNP sched = group.GetSchedule();
                sched.AddLesson(lesson);
                group.SetSchedule(sched);
                return lesson;
            }

            throw new IsuExtraException("Error");
        }

        public LessonGroup AddLessonToGroup(GroupISU group, string teacher, int day, int time, int auditory)
        {
            LessonGroup lesson = new LessonGroup(group, teacher, day, time, auditory);
            ScheduleISU sched = group.GetSchedule();
            sched.AddLesson(lesson);
            group.SetSchedule(sched);
            return lesson;
        }

        public bool PermissionForSigning(GroupOGNP group, List<LessonGroup> isuLessons)
        {
            List<LessonOGNP> lessons = group.GetSchedule().GetSchedule();
            foreach (var lesson in isuLessons)
            {
                foreach (var groupLesson in group.GetSchedule().GetSchedule())
                {
                    if (lesson.GetTime() == groupLesson.GetTime() &&
                        lesson.GetDay() == groupLesson.GetDay())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public ExtraStudent AddStudentToCourse(ExtraStudent student, Course course)
        {
            GroupISU studentGroup = student.GetGroupIsu();
            GroupOGNP groupForSigning = null;
            if (studentGroup.Faculty == course.GetFaculty())
            {
                if (!_allStudent.Contains(student))
                {
                    _allStudent.Add(student);
                }

                throw new IsuExtraException("Student can not sign for this OGNP");
            }

            Flow flowOfCourse = course.GetFlow();
            List<GroupOGNP> groupsOfFlow = flowOfCourse.Groups;
            foreach (var group in groupsOfFlow)
            {
                if (group.CountOfStudents() < group.GetMaxAmount())
                {
                    groupForSigning = group;
                }
            }

            if (PermissionForSigning(groupForSigning, student.GetGroupIsu().GetSchedule().GetSchedule()))
            {
                course.Students.Add(student);
                _signedStudents.Add(student);
                if (!_allStudent.Contains(student))
                {
                    _allStudent.Add(student);
                }

                student.SetGroupOgnp(groupForSigning);
            }
            else
            {
                throw new IsuExtraException("Error");
            }

            return student;
        }

        public Flow GetFlows(Course course)
        {
            return course.GetFlow();
        }

        public List<ExtraStudent> GetStudentsOgnpGroup(GroupOGNP group)
        {
            List<ExtraStudent> students = new List<ExtraStudent>();
            foreach (var course in _allCourses)
            {
                Flow flow = course.GetFlow();
                List<GroupOGNP> listOfGroups = flow.Groups;
                foreach (var group_ in listOfGroups)
                {
                    if (group.GetName() == group.GetName())
                    {
                        students = group_.Students;
                        return students;
                    }
                }
            }

            throw new IsuExtraException("No such group");
        }

        public List<ExtraStudent> GetStudentsFromCourse(Course course, string name)
        {
            List<ExtraStudent> students = new List<ExtraStudent>();
            Flow flow = course.GetFlow();
            foreach (var ognpGroup in flow.Groups)
            {
                if (ognpGroup.GetName() == name)
                {
                    students = ognpGroup.Students;
                    return students;
                }
            }

            throw new IsuExtraException("No such group");
        }

        public List<ExtraStudent> GetNotSignedStudents()
        {
            List<ExtraStudent> students = new List<ExtraStudent>();
            foreach (var student in _allStudent)
            {
                if (!_signedStudents.Contains(student))
                {
                    students.Add(student);
                }
            }

            return students;
        }

        public Student RemoveStudentFromOgnp(ExtraStudent student, Course course)
        {
            foreach (var student_ in course.Students)
            {
                if (student.GetStudentId() == student_.GetStudentId())
                {
                    course.Students.Remove(student);
                    student.SetGroupOgnp(null);
                }
            }

            throw new IsuExtraException("No such student in OGNP course");
        }
    }
}