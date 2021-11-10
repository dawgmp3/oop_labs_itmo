using Isu.Classes;

namespace IsuExtra.Classes
{
    public class LessonGroup
    {
        private string _teacher;
        private int _day;
        private GroupISU _group;
        private int _time;
        private int _auditory;
        public LessonGroup(GroupISU group, string teacher, int day, int time, int auditory)
        {
            _teacher = teacher;
            _day = day;
            _group = group;
            _time = time;
            _auditory = auditory;
        }

        public string GetTeacher()
        {
            return _teacher;
        }

        public int GetDay()
        {
            return _day;
        }

        public GroupISU GetGroup()
        {
            return _group;
        }

        public int GetTime()
        {
            return _time;
        }

        public int GetAuditory()
        {
            return _auditory;
        }
    }
}