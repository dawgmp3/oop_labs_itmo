using System;
using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class ExtraStudent : Student
    {
        public ExtraStudent(string name, Guid id, GroupISU groupIsu)
            : base(name, groupIsu, id)
        {
            GroupIsu = groupIsu;
            GroupsOgnp = new List<GroupOGNP>();
        }

        public List<GroupOGNP> GroupsOgnp { get; set; }

        public GroupISU GroupIsu { get; set; }
    }
}