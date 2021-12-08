using System;
using System.Collections.Generic;
using System.IO.Pipes;

namespace Banks.Classes
{
    public class Bank : IObservable
    {
        private string _name;
        private string _statusOfCommission;
        private string _statusOfPercentage;
        private DateTime _dateOfCreation;
        private int _percentage;
        private int _commission;
        private int _limit;
        private List<IObserver> _notifications;
        public Bank(string name)
        {
            _name = name;
            Clients = new List<Client>();
            _dateOfCreation = new DateTime(0);
            _percentage = 0;
            _commission = 0;
            _limit = 0;
            _statusOfCommission = "No need for commissions this month";
            _statusOfPercentage = "No need for giving percentage";
            _notifications = new List<IObserver>();
        }

        public List<Client> Clients { get; }

        public void SetDayOfCreation()
        {
            _dateOfCreation = DateTime.Today;
        }

        public string GetName()
        {
            return _name;
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void ChangeStatusOfCommissions(string message)
        {
            _statusOfCommission = message;
        }

        public void SetPersentage(int percentage)
        {
            _percentage = percentage;
        }

        public void SetLimit(int limit)
        {
            _limit = limit;
        }

        public int GetLimit()
        {
            return _limit;
        }

        public int GetPersentage()
        {
            return _percentage;
        }

        public void SetCommission(int commission)
        {
            _commission = commission;
        }

        public void ChangeStatusOfPersentage(string message)
        {
            _statusOfPercentage = message;
        }

        public Account OpenCreditAccount(Client client, int amountOfMoneyToBorrow)
        {
            if (client.GetPassport() == string.Empty || client.GetAddress() == string.Empty)
            {
                var creditAccount = new CreditAccount(amountOfMoneyToBorrow, Guid.NewGuid(), "doubtful", client.GetBank());
                client.AddAccount(creditAccount);
                return creditAccount;
            }
            else
            {
                var creditAccount = new CreditAccount(amountOfMoneyToBorrow, Guid.NewGuid(), "not doubtul", client.GetBank());
                client.AddAccount(creditAccount);
                return creditAccount;
            }
        }

        public Account OpenDebitAccount(Client client, int money)
        {
            if (client.GetPassport() == string.Empty || client.GetAddress() == string.Empty)
            {
                Account debitAccount = new DebitAccount(money, _percentage, Guid.NewGuid(), "doubtful", client.GetBank());
                client.AddAccount(debitAccount);
                return debitAccount;
            }
            else
            {
                Account debitAccount = new DebitAccount(money, _percentage, Guid.NewGuid(), "not doubtul", client.GetBank());
                client.AddAccount(debitAccount);
                return debitAccount;
            }
        }

        public Account OpenDepositAccount(Client client, int moneyToPutInAcc)
        {
            if (client.GetPassport() == string.Empty || client.GetAddress() == string.Empty)
            {
                var depositAccount = new DepositAccount(moneyToPutInAcc, Guid.NewGuid(), "doubtful", client.GetBank());
                client.AddAccount(depositAccount);
                return depositAccount;
            }
            else
            {
                var depositAccount = new DepositAccount(moneyToPutInAcc, Guid.NewGuid(), "not doubtul", client.GetBank());
                client.AddAccount(depositAccount);
                return depositAccount;
            }
        }

        public virtual void GiveCommissionToAccount(Client client, CreditAccount account)
        {
            client.GetAccounts().Remove(account);
            if (account.GetAmountOfMoneyNeedToReturn() < account.GetAmountOfBorrowedMoney())
            {
                account.SetAmountOfMoneyNeedToReturn(account.GetAmountOfMoneyNeedToReturn() +
                                                     (client.GetBank().GetPersentage() / 100 *
                                                     account.GetAmountOfMoneyNeedToReturn()));
            }

            client.GetAccounts().Add(account);
        }

        public void GivePercentagesToDebitAccount(Client client, DebitAccount debitAccount)
        {
            debitAccount.SetMoney(debitAccount.GetMoney() + (client.GetBank().GetPersentage()
                / 100 * debitAccount.GetMoney()));
        }

        public void GivePercentagesToDepositAccount(Client client, DepositAccount depositAccount)
        {
            depositAccount.SetMoney(depositAccount.GetMoney() + (client.GetBank().GetPersentage()
                / 100 * depositAccount.GetMoney()));
        }

        public void CancellTransactionSendingMoney(Account accountSender, Account accountCatcher, int money)
        {
            accountSender.SetMoney(accountSender, accountSender.GetMoney() + money);
            accountCatcher.SetMoney(accountCatcher, accountCatcher.GetMoney() - money);
        }

        public void CancellTransactionWithdrawMoney(Account account, int money)
        {
            account.SetMoney(account, account.GetMoney() + money);
        }

        public void AddObserver(IObserver notification)
        {
            _notifications.Add(notification);
        }

        public void RemoveObserver(IObserver notification)
        {
            _notifications.Remove(notification);
        }

        public void NotifyObservers()
        {
            foreach (var client in Clients)
            {
                foreach (var account in client.GetAccounts())
                {
                    account.Update(account, _percentage);
                }
            }
        }
    }
}