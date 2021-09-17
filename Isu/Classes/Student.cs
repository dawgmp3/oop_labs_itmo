using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        private static int _id = 0;
        public Student(string name)
        {
        Name = name;
        Id = (++_id) + 100000;
        }

        public string Name { get; }
        public int Id { get; }
    }
}