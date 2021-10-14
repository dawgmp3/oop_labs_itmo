using System;
using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        public Student(string name, Group group)
        {
        Name = name;
        Group = group;
        Id1 = Guid2Int();
        }

        public int Id1 { get; }

        public Group Group { get; set; }
        public string Name { get; }
        public static Guid Id()
        {
            Guid id = Guid.NewGuid();
            return id;
        }

        public int Guid2Int()
        {
            byte[] b = Id().ToByteArray();
            int bint = BitConverter.ToInt32(b, 0);
            return bint;
        }
    }
}