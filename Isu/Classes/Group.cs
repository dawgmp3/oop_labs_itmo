using System.Collections.Generic;

namespace Isu.Classes
{
    public class Group
    {
        private GroupName nameofgroup;
        private int countofstudents;
        public Group(GroupName name, int amount)
        {
            nameofgroup = name;
            countofstudents = amount;
        }

        public int PlusStudent()
        {
            countofstudents += 1;
            return countofstudents;
        }

        public int MinusStudent()
        {
            countofstudents -= 1;
            return countofstudents;
        }

        public int GetAmount()
        {
            return countofstudents;
        }

        public GroupName GetName()
        {
            return nameofgroup;
        }
    }
}