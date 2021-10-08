using System;
using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        private static int _id = 0;
        public Student(string name, Group group)
        {
        Name = name;
        Group = group;
        Id = (++_id) + 100000;
        }

        public Group Group { get; set; }
        public string Name { get; }
        public int Id { get; }
    }
}