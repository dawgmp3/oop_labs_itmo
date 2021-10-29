using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class GroupISU : Group
    {
        private string _faculty;
        public GroupISU(GroupName name, int amount, string faculty)
            : base(name, amount)
        {
            Lessons = new List<LessonGroup>();
            Students = new List<Student>();
            _faculty = faculty;
        }

        public List<Student> Students { get; }

        public List<LessonGroup> Lessons { get; }
        public string GetFaculty()
        {
            return _faculty;
        }
    }
}