using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class GroupISU : Group
    {
        public GroupISU(GroupName name, int amount)
            : base(name, amount)
        {
            Students = new List<ExtraStudent>();
            Faculty = name.GrName.Substring(0, 1);
            Schedule = new Schedule();
        }

        public Schedule Schedule { get; set; }

        public string Faculty { get; }
        public List<ExtraStudent> Students { get; }
    }
}