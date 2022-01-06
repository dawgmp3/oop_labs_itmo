using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Classes;

namespace IsuExtra.Services
{
    public class Ognp : IOgnp
    {
        private List<Course> _allCourses = new List<Course>();
        private List<ExtraStudent> _allStudent = new List<ExtraStudent>();
        private List<Student> _signedStudents = new List<Student>();

        public Course AddCourse(string name, string faculty, Flow flow)
        {
            if (_allCourses.Any(courseName => name == courseName.Name))
            {
                throw new IsuExtraException("Course already exists");
            }

            Course newCourse = new Course(name, faculty, flow);
            _allCourses.Add(newCourse);
            return newCourse;
        }

        public Flow AddGroupToFlow(Flow flow, GroupOGNP group)
        {
            flow.Groups.Add(group);
            return flow;
        }

        public Lesson AddLessonToFlow(string teacher, int day, GroupOGNP group, int numberOfLesson, int auditory)
        {
            int maxCountOfLessons = 8;
            int countOfDays = 7;
            if (numberOfLesson <= maxCountOfLessons && day <= countOfDays)
            {
                Lesson lesson = new Lesson(teacher, day, numberOfLesson, auditory);
                Schedule scheduleOgnp = group.Schedule;
                scheduleOgnp.AddLesson(lesson);
                return lesson;
            }

            throw new IsuExtraException("Error");
        }

        public Lesson AddLessonToGroup(GroupISU group, string teacher, int day, int time, int auditory)
        {
            Lesson lesson = new Lesson(teacher, day, time, auditory);
            Schedule scheduleIsu = group.Schedule;
            scheduleIsu.AddLesson(lesson);
            return lesson;
        }

        public bool HasScheduleIntersection(GroupOGNP group, List<Lesson> isuLessons, List<GroupOGNP> ognpGroups)
        {
            foreach (var lesson in isuLessons)
            {
                foreach (var groupLesson in group.Schedule.GetSchedule())
                {
                    if (lesson.NumberOfLesson == groupLesson.NumberOfLesson &&
                        lesson.Day == groupLesson.Day)
                    {
                        return false;
                    }
                }
            }

            foreach (var ognpGroup in ognpGroups)
            {
                foreach (var lesson in ognpGroup.Schedule.GetSchedule())
                {
                    foreach (var groupLesson in group.Schedule.GetSchedule())
                    {
                        if (lesson.NumberOfLesson == groupLesson.NumberOfLesson &&
                            lesson.Day == groupLesson.Day)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public ExtraStudent AddStudentToCourse(ExtraStudent student, Course course)
        {
            GroupISU studentGroup = student.GroupIsu;
            GroupOGNP groupForSigning;
            if (studentGroup.Faculty == course.Faculty)
            {
                if (!_allStudent.Contains(student))
                {
                    _allStudent.Add(student);
                }

                throw new IsuExtraException("Student can not sign for this OGNP");
            }

            if (student.GroupsOgnp.Count == 2)
            {
                throw new IsuExtraException("Student has already 2 Ognp groups");
            }

            foreach (var group in course.FlowOfCourse.Groups)
            {
                if (group.CountOfStudents() < group.GetMaxAmount())
                {
                    groupForSigning = group;
                    if (HasScheduleIntersection(groupForSigning, student.GroupIsu.Schedule.GetSchedule(), student.GroupsOgnp)
                        && student.GroupsOgnp.Count < 2)
                    {
                        course.Students.Add(student);
                        groupForSigning.Students.Add(student);
                        _signedStudents.Add(student);
                        if (!_allStudent.Contains(student))
                        {
                            _allStudent.Add(student);
                        }

                        student.GroupsOgnp.Add(groupForSigning);
                    }
                    else
                    {
                        throw new IsuExtraException("Schedule doesn't fit");
                    }
                }
            }

            return student;
        }

        public Flow GetFlows(Course course)
        {
            return course.FlowOfCourse;
        }

        public List<ExtraStudent> GetStudentsOgnpGroup(GroupOGNP group)
        {
            foreach (var course in _allCourses)
            {
                foreach (var groupInFlow in course.FlowOfCourse.Groups.Where(groupInFlow => group.GetName() == groupInFlow.GetName()))
                {
                    return groupInFlow.Students;
                }
            }

            throw new IsuExtraException("No such group");
        }

        public List<ExtraStudent> GetStudentsFromCourse(Course course)
        {
            return course.Students;
        }

        public List<ExtraStudent> GetNotSignedStudents()
        {
            return _allStudent.Where(student => !_signedStudents.Contains(student)).ToList();
        }

        public ExtraStudent RemoveStudentFromOgnp1(ExtraStudent student, Course course)
        {
            foreach (var group in course.FlowOfCourse.Groups)
            {
                foreach (var studentInGroupOgnp in group.Students)
                {
                    if (student.GetStudentId() == studentInGroupOgnp.GetStudentId())
                    {
                        course.Students.Remove(student);
                        group.Students.Remove(student);
                        student.GroupsOgnp.Remove(group);
                        return student;
                    }
                }
            }

            throw new IsuExtraException("No student");
        }
    }
}