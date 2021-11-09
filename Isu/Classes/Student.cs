using System;
using Isu.Services;

namespace Isu.Classes
{
    public class Student
    {
        private string nameofstudent;
        private Group groupofstudent;
        private Guid idofstudent;

        public Student(StudentBuilder student)
        {
            nameofstudent = student.GetName();
            groupofstudent = student.GetGroup();
            idofstudent = student.Id();
        }

        public void SetGroup(Group group)
        {
            groupofstudent = group;
        }

        public Group GetStudentGroup()
        {
            return groupofstudent;
        }

        public string GetStudentName()
        {
            return nameofstudent;
        }

        public Guid GetStudentId()
        {
            return idofstudent;
        }
    }
}