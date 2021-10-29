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
        private IOGNP _ognp;
        
        [SetUp]
        public void Setup()
        {
            _ognp = new OGNP();
        }
        
        [Test]
        public void AddCourse()
        {
             Assert.Catch<IsuExtraException>(() =>
             {
                Flow flow = new Flow("bark");
                Flow flow1 = new Flow("wee");
                Course course = _ognp.AddCourse("meow", "ITIP", 30, flow);
                Course course1 = _ognp.AddCourse("meow", "ITIP1", 32, flow1);
                
             });
        }
    }
}