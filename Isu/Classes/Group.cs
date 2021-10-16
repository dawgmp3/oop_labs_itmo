using System.Collections.Generic;

namespace Isu.Classes
{
    public class Group
    {
        private int _studentCount = 0;
        public Group(GroupName name)
        {
            Name = name;
        }

        public GroupName Name { get; }
        public void CountOfStudents()
        {
            ++_studentCount;
        }

        public void MinusCount()
        {
            --_studentCount;
        }

        public int GetCountOfStudents()
        {
            return _studentCount;
        }
    }
}