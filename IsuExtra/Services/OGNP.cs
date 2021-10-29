using System;
using System.Collections.Generic;
using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Classes;

namespace IsuExtra.Services
{
    public class OGNP : IOGNP
    {
        private List<Course> _allCourses = new List<Course>();
        private List<Student> _allStudent = new List<Student>();
        private IIsuService _isuService = new IsuServices(20);
        private List<Student> _signedStudents = new List<Student>();
        private List<Student> _notSignedStudents = new List<Student>();

        public Course AddCourse(string name, string faculty, int amount, Flow flow)
        {
            foreach (Course courseName in _allCourses)
            {
                if (name == courseName.GetName())
                {
                    throw new IsuExtraException("Course already exists");
                }
            }

            Course newCourse = new Course(name, faculty, amount, flow);
            Course.CourseBuilder builder = new Course.CourseBuilder();
            Course.CourseBuilder build = Course.ToBuild(builder);
            Course course = build.Build();
            newCourse = course;
            _allCourses.Add(newCourse);
            return newCourse;
        }

        public Student AddStudent(string name, GroupISU group, int id)
        {
            Student student = _isuService.AddStudent(name, group, id);
            ScheduleISU schedule = new ScheduleISU(student);
            _notSignedStudents.Add(student);
            return student;
        }

        public Flow AddFlow(string name, GroupOGNP group1, GroupOGNP group2, GroupOGNP group3)
        {
            Flow flow = new Flow(name);
            flow.Groups.Add(group1);
            flow.Groups.Add(group2);
            flow.Groups.Add(group3);
            return flow;
        }

        public LessonOGNP AddLessonToFlow(Flow flow, Course course, string teacher, string day, GroupOGNP group, int hour, int minutes, int auditory)
        {
            LessonOGNP lesson = new LessonOGNP(teacher, day, group, hour, minutes, auditory);
            group.Lessons.Add(lesson);
            return lesson;
        }

        public LessonGroup AddLessonToGroup(GroupISU group, Course course, string teacher, string day, int hour, int minutes, int auditory)
        {
            LessonGroup lesson = new LessonGroup(group, teacher, day, hour, minutes, auditory);
            group.Lessons.Add(lesson);
            return lesson;
        }

        public bool PermissionForSigning(GroupOGNP group, ScheduleISU studentsSchedule)
        {
            foreach (var lesson in studentsSchedule.GetSchedule())
            {
                foreach (var groupLesson in group.Lessons)
                {
                    if (lesson.GetHour() == groupLesson.GetHour() &&
                        lesson.GetMinutes() == groupLesson.GetMinutes())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Student AddStudentToCourse(Student student, Course course)
        {
            GroupOGNP groupOgnp = null;
            bool res = false;
            foreach (var course_ in _allCourses)
            {
                if (course_.GetName() != course.GetName())
                {
                    throw new IsuExtraException("There is no such course");
                }

                foreach (Student student_ in course.Students)
                {
                    if (student_.GetStudentName() == student.GetStudentName())
                    {
                        throw new IsuExtraException("Student already exists");
                    }
                }
            }

            Flow flow = course.GetFlow();

            foreach (var group in flow.Groups)
            {
                if (group.CountOfStudents() < group.GetMaxAmount())
                {
                    groupOgnp = group;
                }
            }

            if (groupOgnp != null)
            {
                if (PermissionForSigning(groupOgnp, new ScheduleISU(student)))
                {
                    foreach (var ognpGroup in flow.Groups)
                    {
                        if (ognpGroup.CountOfStudents() < ognpGroup.GetMaxAmount())
                        {
                            res = true;
                        }
                        else
                        {
                            throw new IsuExtraException("No place");
                        }
                    }
                }
            }

            if (res)
            {
                course.Students.Add(student);
                _notSignedStudents.Remove(student);
                _signedStudents.Add(student);
            }

            return student;
        }

        public Flow GetFlows(Course course)
        {
            return course.GetFlow();
        }

        public List<Student> GetStudents(Course course, string name)
        {
            List<Student> students = new List<Student>();
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

        public List<Student> GetNotSignedStudents()
        {
            return _notSignedStudents;
        }

        public Student RemoveStudentFromOgnp(Student student, Course course)
        {
            foreach (var student_ in course.Students)
            {
                if (student.GetStudentId() == student_.GetStudentId())
                {
                    course.Students.Remove(student);
                }
            }

            throw new IsuExtraException("No such student in OGNP course");
        }
    }
}