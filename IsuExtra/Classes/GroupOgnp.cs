using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class GroupOGNP
    {
        public GroupOGNP(string name, int max)
        {
            Name = name;
            MaxCount = max;
            Students = new List<ExtraStudent>();
            Schedule = new Schedule();
        }

        public int MaxCount { get; set; }

        public string Name { get; set; }

        public Schedule Schedule { get; set; }

        public List<ExtraStudent> Students { get; }
    }
}