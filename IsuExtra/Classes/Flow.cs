using System.Collections.Generic;
using Isu.Classes;
using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Flow
    {
        private string _name;
        public Flow(string name)
        {
            _name = name;
            Groups = new List<GroupOGNP>();
        }

        public List<GroupOGNP> Groups { get; }

        public GroupOGNP FindGroupForSigning()
        {
            foreach (GroupOGNP group in Groups)
            {
                if (group.CountOfStudents() < group.GetMaxAmount())
                {
                    return group;
                }
            }

            throw new IsuExtraException("No place");
        }
    }
}