using System;
using System.Collections.Generic;
using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Classes;
using IsuExtra.Services;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class OgnpTests
    {
        private IOgnp _ognp;
        
        [SetUp]
        public void Setup()
        {
            _ognp = new Ognp();
        }

        [Test]
        public void AddCourse()
        {
            Flow flow = new Flow("bark");
            Flow flow1 = new Flow("wee");
            Course course = _ognp.AddCourse("meow", "ITIP", flow);
            Assert.Catch<IsuExtraException>(() =>
            {
                Course course1 = _ognp.AddCourse("meow", "ITIP1", flow1);
            });
        }

        [Test]
        public void AddStudentToCourse()
        {
            GroupName name = new GroupName("M3209");
            GroupISU group = new GroupISU(name, 20);
            Flow flow = new Flow("1");
            Course course = _ognp.AddCourse("Кибербез", "M", flow);
            ExtraStudent student = new ExtraStudent("Misha", new Guid(), group);
            Assert.Catch<IsuExtraException>(() =>
            {
                _ognp.AddStudentToCourse(student, course);
            });
        }
        [Test]
        public void RemoveStudentFromCourse()
        {
            GroupName name = new GroupName("M3209");
            GroupISU group = new GroupISU(name, 20);
            Flow flow = new Flow("1");
            Course course = _ognp.AddCourse("Кибербез", "F", flow);
            ExtraStudent student1 = new ExtraStudent("Misha1", new Guid(), group);
            Assert.Catch<IsuExtraException>(() =>
            {
                _ognp.RemoveStudentFromOgnp(student1, course);
            });
        }
        [Test]
        public void AddStudentToCourse2()
        {
            GroupName name = new GroupName("M3209");
            GroupISU group = new GroupISU(name, 20);
            GroupOGNP groupOgnp1 = new GroupOGNP("2", 20);
            GroupOGNP groupOgnp2 = new GroupOGNP("3", 20);
            GroupOGNP groupOgnp3 = new GroupOGNP("4", 20);
            _ognp.AddLessonToGroup(group, "Maria", 1, 2, 111);
            Flow flow = new Flow("1");
            
            _ognp.AddLessonToFlow("Maria", 1, groupOgnp1, 2, 256);
            _ognp.AddLessonToFlow("Maria", 1, groupOgnp2, 2, 256);
            _ognp.AddLessonToFlow("Maria", 1, groupOgnp3, 2, 256);
            _ognp.AddGroupToFlow(flow, groupOgnp1);
            _ognp.AddGroupToFlow(flow, groupOgnp2);
            _ognp.AddGroupToFlow(flow, groupOgnp3);
            
            Course course = _ognp.AddCourse("Кибербез", "F", flow);
            ExtraStudent student = new ExtraStudent("Misha", new Guid(), group);
            Assert.Catch<IsuExtraException>(() =>
            {
                _ognp.AddStudentToCourse(student, course);
            });
        }
        [Test]
        public void AddStudentToCourse_HeHasOgnp()
        {
            GroupName name = new GroupName("M3209");
            GroupISU group = new GroupISU(name, 20);
            GroupOGNP groupOgnp1 = new GroupOGNP("2", 20);
            _ognp.AddLessonToGroup(group, "Maria", 1, 3, 111);
            Flow flow = new Flow("1");
            
            _ognp.AddLessonToFlow("Maria", 1, groupOgnp1, 2, 256);
            _ognp.AddGroupToFlow(flow, groupOgnp1);
            
            Course course = _ognp.AddCourse("Кибербез", "F", flow);
            
            GroupOGNP groupOgnp1_2 = new GroupOGNP("2", 20);
            Flow flow2 = new Flow("1");
            
            _ognp.AddLessonToFlow("Maria", 1, groupOgnp1_2, 5, 256);
            _ognp.AddGroupToFlow(flow2, groupOgnp1_2);
            
            Course course2 = _ognp.AddCourse("Кибербезз", "L", flow2);
            
            ExtraStudent student = new ExtraStudent("Misha", new Guid(), group);
            _ognp.AddStudentToCourse(student, course2);
            Assert.Catch<IsuExtraException>(() =>
            {
                _ognp.AddStudentToCourse(student, course);
            });
        }
    }
}