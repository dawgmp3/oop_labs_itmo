using System;
using Banks.Classes;
using Banks.Services;
using Banks.Tools;
using NUnit.Framework;

namespace Banks.Tests

{
    public class BanksTests
    {
        private IBanksManager _banksManager;
        [SetUp]
        public void Setup()
        {
            _banksManager = null;
        }
        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
        }
    }
}