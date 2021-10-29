using System.Collections.Generic;
using Isu.Classes;

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
    }
}