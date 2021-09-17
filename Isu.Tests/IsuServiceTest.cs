using Isu.Classes;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuServices();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group newgroup = _isuService.AddGroup("M3209");
            Student newstudent = _isuService.AddStudent(newgroup,"Misha");
            Assert.Contains(newstudent, newgroup.Students);
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
            Student student = _isuService.AddStudent(newgroup1, "Misha");
            _isuService.ChangeStudentGroup(student, newgroup2);
            Assert.Contains(student, newgroup2.Students);
        }
    }
}