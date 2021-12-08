using System;
using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Classes
{
    public abstract class Account : IObserver
    {
        private int _money;
        private Guid _id;
        private string _isDoubtful;
        private Bank _bank;
        public Account(int money, Guid id, string isDoubtful, Bank bank)
        {
            _money = money;
            _id = id;
            _isDoubtful = isDoubtful;
            _bank = bank;
        }

        public virtual int GetMoney()
        {
            return _money;
        }

        public virtual void PutMoneyInAcc(Account account, int money)
        {
            account._money = _money + money;
        }

        public virtual void SetMoney(Account account, int money)
        {
            account._money = money;
        }

        public virtual int ToSeeHowMuchInSomeMonth(Bank bank, Account account, int amountOfMonth)
        {
            int final = account.GetMoney();
            for (int i = 0; i < amountOfMonth; i++)
            {
                final = final + (account.GetMoney() * bank.GetPersentage() / 100);
            }

            return final;
        }

        public virtual int ToSeeHowMuchInSomeYears(Bank bank, Account account, int amountOfYears)
        {
            int percentInYear = bank.GetPersentage() * 12;
            int final = account.GetMoney();
            for (int i = 0; i < amountOfYears; i++)
            {
                final = final + (account.GetMoney() * percentInYear / 100);
            }

            return final;
        }

        public virtual void WithdrawMoney(Bank bank, Account account, int money)
        {
            int limit = bank.GetLimit();
            if (account._isDoubtful == "doubtful")
            {
                if (money > limit)
                {
                    throw new BanksException("client can not withdraw money above limit");
                }
            }

            if (_money >= money)
            {
                _money = _money - money;
            }
            else
            {
                throw new BanksException("Not enough money");
            }
        }

        public virtual void SetMoney(int money)
        {
            _money = money;
        }

        public Bank GetBank()
        {
            return _bank;
        }

        public virtual void TransferMoneyToAnotherClient(Account accountSender, Account accountCatcher, int moneyToSend)
        {
            if (accountSender._isDoubtful == "yes")
            {
                if (moneyToSend > accountSender.GetBank().GetLimit())
                {
                    throw new BanksException("Client can not send money because he is doubtful");
                }
            }

            if (accountSender.GetMoney() >= moneyToSend && accountSender.GetMoney() - moneyToSend >= 0)
            {
                accountSender.SetMoney(accountSender, accountSender.GetMoney() - moneyToSend);
                accountCatcher.PutMoneyInAcc(accountCatcher, moneyToSend);
            }
        }

        public virtual string GetIsDoubtful()
        {
            return _isDoubtful;
        }

        public virtual void SetIsDoubtful(string isDoubtful)
        {
            _isDoubtful = isDoubtful;
        }

        public void Update(Account account, int percentage)
        {
            Bank bank = account._bank;
            bank.SetPersentage(percentage);
        }
    }
}