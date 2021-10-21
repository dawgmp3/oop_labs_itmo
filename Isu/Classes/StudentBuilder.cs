using System;

namespace Isu.Classes
{
    public class StudentBuilder
    {
        private string name;
        private Group group;
        private Guid id;

        public StudentBuilder NameStudent(string newname)
        {
            name = newname;
            return this;
        }

        public StudentBuilder GroupStudent(Group newgroup)
        {
            group = newgroup;
            return this;
        }

        public StudentBuilder IdStudent(Guid newid)
        {
            id = newid;
            return this;
        }

        public string GetName()
        {
            return name;
        }

        public Group GetGroup()
        {
            return group;
        }

        public Guid Id()
        {
            return id;
        }

        public StudentBuilder ToBuild()
        {
            StudentBuilder studentbuilder = new StudentBuilder();
            studentbuilder.NameStudent(name);
            studentbuilder.GroupStudent(group);
            studentbuilder.IdStudent(id);
            return studentbuilder;
        }

        public Student Build()
        {
            Student student = new Student(ToBuild());
            return student;
        }
    }
}