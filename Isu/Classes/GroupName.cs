using System;

namespace Isu.Classes
{
    public class GroupName
    {
        public GroupName(string name)
        {
            GrName = name;
            CourseNumber = (CourseNumber)int.Parse(name.Substring(2, 1));
            GroupNumber = int.Parse(name.Substring(3, 2));
        }

        public CourseNumber CourseNumber { get; }
        public int GroupNumber { get; }
        public string GrName { get; }
    }
}