using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class Course
    {
        public Course(string name, string faculty, Flow flow)
        {
            Name = name;
            Faculty = faculty;
            Students = new List<ExtraStudent>();
            FlowOfCourse = flow;
        }

        public Flow FlowOfCourse { get; set; }

        public string Faculty { get; set; }

        public string Name { get; set; }

        public List<ExtraStudent> Students { get; }
    }
}