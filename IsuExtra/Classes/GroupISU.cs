using System.Collections.Generic;
using Isu.Classes;

namespace IsuExtra.Classes
{
    public class GroupISU : Group
    {
        private ScheduleISU _schedule;
        public GroupISU(GroupName name, int amount)
            : base(name, amount)
        {
            Students = new List<ExtraStudent>();
            Faculty = name.GrName.Substring(0, 1);
            _schedule = new ScheduleISU();
        }

        public string Faculty { get; }
        public List<ExtraStudent> Students { get; }

        public ScheduleISU GetSchedule()
        {
            return _schedule;
        }

        public void SetSchedule(ScheduleISU schedule)
        {
            _schedule = schedule;
        }
    }
}