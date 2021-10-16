using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;
        private int _maxAmountInGroup;
        
        [SetUp]
        public void Setup()
        {
            _maxAmountInGroup = 30;
            _isuService = new IsuServices(_maxAmountInGroup);
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group newgroup = _isuService.AddGroup("M3209");
            Student newstudent = _isuService.AddStudent(newgroup,"Misha");
            Assert.AreEqual(newstudent.Group, newgroup);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group newgroup = _isuService.AddGroup("M3210");
            Assert.Catch<IsuException>(() =>
            {
                for (var i = 0; i < 31; ++i)
                {
                    _isuService.AddStudent(newgroup, "Misha");
                }
                
            });
        }

        [TestCase("P3209")]
        [TestCase("M3509")]    
        public void CreateGroupWithInvalidName_ThrowException(string name)
        {
            Assert.Catch<IsuException>(() =>
            {
                Group newgroup = _isuService.AddGroup(name);
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group newgroup1 = _isuService.AddGroup("M3105");
            Group newgroup2 = _isuService.AddGroup("M3106");
            Student stud1 = _isuService.AddStudent(newgroup1, "Misha");
            _isuService.ChangeStudentGroup(stud1, newgroup2);
            Assert.AreEqual(stud1.Group.Name.GrName, newgroup2.Name.GrName);
        }
    }
}