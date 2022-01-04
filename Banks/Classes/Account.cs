using System;
using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Classes
{
    public abstract class Account : IObserver
    {
        private int _money;
        private Guid _id;
        private Bank _bank;
        private Client _client;
        public Account(int money, Bank bank, Client client)
        {
            _money = money;
            _id = Guid.NewGuid();
            _bank = bank;
            _client = client;
        }

        public virtual int GetMoney()
        {
            return _money;
        }

        public virtual void PutMoneyInAcc(int money)
        {
            _money = _money + money;
        }

        public virtual int ToSeeHowMuchInSomeMonths(Bank bank, int amountOfMonth)
        {
            return AddPercentage(bank.GetPersentage(), amountOfMonth);
        }

        public virtual int ToSeeHowMuchInSomeYears(Bank bank, int amountOfYears)
        {
            return AddPercentage(bank.GetPersentage() * 12, amountOfYears);
        }

        public int AddPercentage(int percent, int time)
        {
            int final = _money;
            for (int i = 0; i < time; i++)
            {
                final += _money * percent / 100;
            }

            return final;
        }

        public virtual void WithdrawMoney(int money)
        {
            if (!_client.CheckIsDoubtful())
            {
                if (money > _money)
                {
                    throw new BanksException("client can not withdraw money above limit");
                }
            }

            if (_money >= money)
            {
                _money = _money - money;
                Transaction transaction = new Transaction(money, null, this);
            }
            else
            {
                throw new BanksException("Not enough money");
            }
        }

        public Bank GetBank()
        {
            return _bank;
        }

        public virtual Transaction TransferMoneyToAnotherClient(Account accountSender, Account accountCatcher, int moneyToSend)
        {
            if (!accountSender._client.CheckIsDoubtful())
            {
                if (moneyToSend > accountSender.GetBank().GetLimit())
                {
                    throw new BanksException("Client can not send money because he is doubtful");
                }
            }

            if (accountSender.GetMoney() >= moneyToSend)
            {
                accountSender.WithdrawMoney(moneyToSend);
                accountCatcher.PutMoneyInAcc(moneyToSend);
            }

            Transaction transaction = new Transaction(moneyToSend, accountCatcher, accountSender);
            return transaction;
        }

        public void Update(Account account, int percentage)
        {
            Bank bank = account._bank;
            bank.SetPersentage(percentage);
        }
    }
}