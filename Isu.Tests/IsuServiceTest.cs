using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;
        private int _maxStudentt;
        
        [SetUp]
        public void Setup()
        {
            _maxStudentt = 30;
            _isuService = new IsuServices(_maxStudentt);
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
            Assert.Catch<IsuException>(() =>
            {
                Group newgroup = _isuService.AddGroup("M3210");
                for (var i = 0; i < 31; ++i)
                {
                    _isuService.AddStudent(newgroup, "Misha");
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group newgroup = _isuService.AddGroup("P3109");
                Group newgroup_ = _isuService.AddGroup("M4109");
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