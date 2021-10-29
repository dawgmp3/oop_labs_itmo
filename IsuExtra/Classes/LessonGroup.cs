using Isu.Classes;

namespace IsuExtra.Classes
{
    public class LessonGroup
    {
        private string _teacher;
        private string _day;
        private GroupISU _group;
        private int _hour;
        private int _minutes;
        private int _auditory;
        public LessonGroup(GroupISU group, string teacher, string day, int hour, int minutes, int auditory)
        {
            _teacher = teacher;
            _day = day;
            _group = group;
            _hour = hour;
            _minutes = minutes;
            _auditory = auditory;
        }

        public string GetTeacher()
        {
            return _teacher;
        }

        public string GetDay()
        {
            return _day;
        }

        public GroupISU GetGroup()
        {
            return _group;
        }

        public int GetHour()
        {
            return _hour;
        }

        public int GetMinutes()
        {
            return _minutes;
        }

        public int GetAuditory()
        {
            return _auditory;
        }
    }
}