namespace IsuExtra.Classes
{
    public class LessonOGNP
    {
        private string _teacher;
        private int _day;
        private GroupOGNP _group;
        private int _time;
        private int _auditory;
        public LessonOGNP(string teacher, int day, GroupOGNP group, int time, int auditory)
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

        public GroupOGNP GetGroup()
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