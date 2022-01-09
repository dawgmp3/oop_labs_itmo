using System;
using System.Collections.Generic;
using System.IO.Pipes;
using Banks.Tools;

namespace Banks.Classes
{
    public class Bank : IObservable, IObserverBanks
    {
        private List<Client> _doubtfulClients = new List<Client>();
        private string _name;
        private int _percentage;
        private int _commission;
        private int _limit;
        private List<IObserver> _notifications;
        private int _highLimitDepositAcc;
        private int _lowLimitDepositAcc;
        private int _percentageHighLimit;
        private int _percentageLowLimit;
        private List<Transaction> _transactions;
        public Bank(string name)
        {
            _name = name;
            _percentageLowLimit = 0;
            _percentageHighLimit = 0;
            _lowLimitDepositAcc = 0;
            _highLimitDepositAcc = 0;
            Clients = new List<Client>();
            _percentage = 0;
            _commission = 0;
            _limit = 0;
            _notifications = new List<IObserver>();
            _transactions = new List<Transaction>();
        }

        public List<Client> Clients { get; }

        public void CreateTransaction(int money, Account catcherAccount, Account senderAccount)
        {
            Transaction transaction = new Transaction(money, catcherAccount, senderAccount);
            _transactions.Add(transaction);
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }

        public void SetHighLimitDepositAcc(int amountOfMoney)
        {
            _highLimitDepositAcc = amountOfMoney;
        }

        public void SetLowLimitDepositAcc(int amountOfMoney)
        {
            _lowLimitDepositAcc = amountOfMoney;
        }

        public void SetHighPercentageDepositAcc(int percentage)
        {
            _percentageHighLimit = percentage;
        }

        public void SetLowPercentageDepositAcc(int percentage)
        {
            _percentageLowLimit = percentage;
        }

        public int GetHighLimitDepositAcc()
        {
            return _highLimitDepositAcc;
        }

        public int GetLowLimitDepositAcc()
        {
            return _lowLimitDepositAcc;
        }

        public int GetHighPercentageDepositAcc()
        {
            return _percentageHighLimit;
        }

        public int GetLowPercentageDepositAcc()
        {
            return _percentageLowLimit;
        }

        public string GetName()
        {
            return _name;
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
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

        public Account OpenCreditAccount(Client client, int amountOfMoneyToBorrow)
        {
            var creditAccount = new CreditAccount(amountOfMoneyToBorrow, client.BankClient, client);
            client.Accounts.Add(creditAccount);
            return creditAccount;
        }

        public Account OpenDebitAccount(Client client, int money)
        {
            Account debitAccount = new DebitAccount(money, client.BankClient, client);
            client.Accounts.Add(debitAccount);
            return debitAccount;
        }

        public Account OpenDepositAccount(Client client, int moneyToPutInAcc)
        {
            var depositAccount = new DepositAccount(moneyToPutInAcc, client.BankClient, client);
            client.Accounts.Add(depositAccount);
            return depositAccount;
        }

        public void GiveCommissionToCreditAccount(CreditAccount account)
        {
            if (account.AmountOfMoneyNeedToReturn < 0)
            {
                account.AmountOfMoneyNeedToReturn = account.AmountOfMoneyNeedToReturn +
                                                    (_commission / 100 * account.AmountOfMoneyNeedToReturn);
            }
        }

        public void GivePercentagesToDebitAccount(DebitAccount debitAccount)
        {
            debitAccount.PutMoneyInAcc(_percentage / 100 * debitAccount.GetMoney());
        }

        public void GivePercentagesToDepositAccount(DepositAccount depositAccount)
        {
            depositAccount.PutMoneyInAcc(_percentage / 100 * depositAccount.GetMoney());
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
                foreach (var account in client.Accounts)
                {
                    account.Update(account, _percentage);
                }
            }
        }

        public Client CreateClient(string name, string surname, string address = "", string passport = "")
        {
            var builder = new Client.ClientBuilder();
            builder.WithName(name)
                .WithSurname(surname)
                .WithAddress(address)
                .WithPassport(passport)
                .WithAccount();
            Client newClient = builder.Build();
            newClient.BankClient = this;
            _doubtfulClients.Add(newClient);
            if (newClient.Name == null && newClient.Surname == null)
            {
                throw new BanksException("You can not registrate client w/o name and surname");
            }

            return newClient;
        }

        public void AddClientAddress(Client client, string address)
        {
            client.Address = address;
        }

        public void AddClientPassport(Client client, string passport)
        {
            client.Passport = passport;
        }

        public void UpdateBanks(CentralBank bank)
        {
            foreach (var client in Clients)
            {
                foreach (CreditAccount acc in client.Accounts)
                {
                    GiveCommissionToCreditAccount(acc);
                }

                foreach (DebitAccount acc in client.Accounts)
                {
                    GivePercentagesToDebitAccount(acc);
                }

                foreach (DepositAccount acc in client.Accounts)
                {
                    GivePercentagesToDepositAccount(acc);
                }
            }
        }
    }
}