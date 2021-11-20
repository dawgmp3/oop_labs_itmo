using System;
using System.Collections.Generic;
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
                ScheduleOGNP sched = group.GetSchedule();
                sched.AddLesson(lesson);
                group.SetSchedule(sched);
                return lesson;
            }

            throw new IsuExtraException("Error");
        }

        public Lesson AddLessonToGroup(GroupISU group, string teacher, int day, int time, int auditory)
        {
            Lesson lesson = new Lesson(teacher, day, time, auditory);
            ScheduleISU sched = group.GetSchedule();
            sched.AddLesson(lesson);
            group.SetSchedule(sched);
            return lesson;
        }

        public GroupOGNP PermissionForSigning(GroupOGNP group, List<Lesson> isuLessons)
        {
            GroupOGNP groupForSigning = null;
            List<Lesson> lessons = group.GetSchedule().GetSchedule();
            foreach (var lesson in isuLessons)
            {
                foreach (var groupLesson in lessons)
                {
                    if (lesson.GetNumberOfLesson() == groupLesson.GetNumberOfLesson() &&
                        lesson.GetDay() == groupLesson.GetDay())
                    {
                        return null;
                    }
                }
            }

            groupForSigning = group;
            return groupForSigning;
        }

        public ExtraStudent AddStudentToCourse(ExtraStudent student, Course course)
        {
            GroupISU studentGroup = student.GetGroupIsu();
            GroupOGNP groupForSigning = null;
            bool permission = false;
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
                    GroupOGNP checkGroup = PermissionForSigning(groupForSigning, student.GetGroupIsu().GetSchedule().GetSchedule());
                    if (checkGroup == groupForSigning)
                    {
                        permission = true;
                        break;
                    }
                }
            }

            if (permission && student.GetGroupOgnp() == null)
            {
                course.Students.Add(student);
                groupForSigning.Students.Add(student);
                _signedStudents.Add(student);
                if (!_allStudent.Contains(student))
                {
                    _allStudent.Add(student);
                }

                student.SetGroupOgnp(groupForSigning);
            }
            else
            {
                if (student.GetGroupOgnp() != null)
                {
                    throw new IsuExtraException("Student has already Ognp group");
                }

                if (permission == false)
                {
                    throw new IsuExtraException("Schedule doesn't fit");
                }
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

        public ExtraStudent RemoveStudentFromOgnp(ExtraStudent student, Course course)
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