using System;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class ExtraStudent : Student
    {
        private GroupOGNP _groupOgnp;
        private GroupISU _group;
        private string _name;
        private Guid _id;
        public ExtraStudent(string name, Guid id, GroupISU groupIsu)
            : base(name, groupIsu, id)
        {
            _name = name;
            _group = groupIsu;
            _id = id;
            _groupOgnp = null;
        }

        public void SetGroupOgnp(GroupOGNP newGroup)
        {
            _groupOgnp = newGroup;
        }

        public GroupISU GetGroupIsu()
        {
            return _group;
        }

        public GroupOGNP GetGroupOgnp()
        {
            return _groupOgnp;
        }
    }
}