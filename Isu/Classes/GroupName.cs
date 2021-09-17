namespace Isu.Classes
{
    public class GroupName
    {
        public GroupName(string name)
        {
            JustName = name;
            Specialty = name.Substring(0, 2);
            CourseNumber = new CourseNumber(int.Parse(name.Substring(2, 1)));
            GroupNumber = int.Parse(name.Substring(3, 2));
        }

        public string Specialty { get; }
        public CourseNumber CourseNumber { get; }
        public int GroupNumber { get; }
        public string JustName { get; }
    }
}