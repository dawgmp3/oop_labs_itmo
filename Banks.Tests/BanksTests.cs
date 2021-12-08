using System;
using Banks.Classes;
using Banks.Tools;
using NUnit.Framework;

namespace Banks.Tests

{
    public class BanksTests
    {
        private CentralBank _centralBank;
        [SetUp]
        public void Setup()
        {
            _centralBank = new CentralBank();
        }
        [Test]
        public void WithdrawMoneyWhenClientHasNoMoney()
        {
            Bank bank = new Bank("ProtectorOfMoney");
            _centralBank.BankRegistration(bank, 10, 10, 100000);
            Client client = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account debitAccount = bank.OpenDebitAccount(client, 100);
            Assert.Catch<BanksException>(() =>
            {
                debitAccount.WithdrawMoney(bank, debitAccount,1000);
            });
        }
        [Test]
        public void WithdrawMoneyFromDepositAcc()
        {
            Bank bank = new Bank("ProtectorOfMoney");
            _centralBank.BankRegistration(bank, 10, 10, 100000);
            Client client = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account depositAccount = bank.OpenDepositAccount(client, 100);
            Assert.Catch<BanksException>(() =>
            {
                depositAccount.WithdrawMoney(bank, depositAccount,10);
            });
        }
        [Test]
        public void TransferMoneyToAnotherClientFromDepositAcc()
        {
            Bank bank = new Bank("ProtectorOfMoney");
            _centralBank.BankRegistration(bank, 10, 10, 10000);
            Client client = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account depositAccount = bank.OpenDepositAccount(client, 100);
            Bank bank2 = new Bank("Meow");
            _centralBank.BankRegistration(bank2, 20, 20, 100000);
            Client client2 = _centralBank.CreateClient("Masha", "Marievna");
            bank.AddClient(client2);
            Account depositAccount2 = bank.OpenDepositAccount(client2, 100);
            Assert.Catch<BanksException>(() =>
            {
                depositAccount.TransferMoneyToAnotherClient(depositAccount, depositAccount2, 10);
            });
        }
        [Test]
        public void WithdrawMoneyFromDoubtfulAcc()
        {
            Bank bank = new Bank("ProtectorOfMoney");
            _centralBank.BankRegistration(bank, 10, 10, 100);
            Client client = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account depositAccount = bank.OpenDepositAccount(client, 1000000);
            Assert.Catch<BanksException>(() =>
            {
                depositAccount.WithdrawMoney(bank, depositAccount,10000);
            });
        }

        [Test]
        public void TransferMoney()
        {
            Bank bank = new Bank("Meow");
            _centralBank.BankRegistration(bank, 10, 10, 1000000);
            Client client = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account debitAccount = bank.OpenDebitAccount(client, 10000);
            Bank bank1 = new Bank("Bark");
            _centralBank.BankRegistration(bank1, 10, 10, 1000000);
            Client client1 = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account debitAccount1 = bank.OpenDebitAccount(client1, 1000);
            debitAccount.TransferMoneyToAnotherClient(debitAccount, debitAccount1, 1);
            Assert.AreEqual(1001, debitAccount1.GetMoney());
        }
        [Test]
        public void FutureAmountOfMoneyInAYear()
        {
            Bank bank = new Bank("Meow");
            _centralBank.BankRegistration(bank, 10, 10, 1000000);
            Client client = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account depositAccount = bank.OpenDepositAccount(client, 10);
            int amountOfMoney = depositAccount.ToSeeHowMuchInSomeYears(bank, depositAccount, 1);
            Assert.AreEqual(22, amountOfMoney);
        }
        [Test]
        public void DoubtfulClientTriesToWithdrawALotOfMoney()
        {
            Bank bank = new Bank("ProtectorOfMoney");
            _centralBank.BankRegistration(bank, 10, 10, 1000);
            Client client = _centralBank.CreateClient("Misha", "Makarov");
            bank.AddClient(client);
            Account debitAccount = bank.OpenDebitAccount(client, 10000);
            Assert.Catch<BanksException>(() =>
            {
                debitAccount.WithdrawMoney(bank, debitAccount,9999);
            });
        }
    }
}