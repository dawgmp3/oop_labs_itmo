using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public abstract class Account
    {
        private int _money;
        public Account(int money)
        {
            _money = money;
        }

        public virtual int GetMoney()
        {
            return _money;
        }

        public virtual int ToSeeHowMuchInSomeDays(int amountOfLoan, int percent, int amountOfDays)
        {
            int plusMoney = amountOfLoan * percent / 100;
            for (int i = 0; i < amountOfDays; i++)
            {
                int final = amountOfLoan + plusMoney;
            }

            return plusMoney;
        }

        public virtual void WithdrawMoney(Client client, int money)
        {
            if (client.GetMoney() >= money && client.GetMoney() - money >= 0)
            {
                client.SetMoney(client.GetMoney() - money);
            }
        }

        public virtual void WithdrawMoneyToAnotherClient(Client clientSender, Client clientCatcher, int moneyToSend)
        {
            if (clientSender.GetMoney() >= moneyToSend && clientSender.GetMoney() - moneyToSend >= 0)
            {
                clientSender.SetMoney(clientSender.GetMoney() - moneyToSend);
                ToGetMoney(clientCatcher, moneyToSend);
            }
        }

        public virtual void ToGetMoney(Client client, int amountOfMoney)
        {
            client.SetMoney(client.GetMoney() + amountOfMoney);
        }

        public virtual void GiveCommissionToAccount(Client client, CreditAccount creditAcc)
        {
            CreditAccount account = client.FindCreditAccount(creditAcc);
            if (client.GetMoney() < account._money)
            {
                account.SetAmountOfMoneyNeedToReturn(account.GetAmountOfMoneyNeedToReturn() +
                                                     (client.GetBank().GetPersentage() / 100 *
                                                      account.GetAmountOfMoneyNeedToReturn()));
            }
        }

        public virtual void GivePercentagesToAccount(Client client, DebitAccount debitAccount, DepositAccount depositAccount)
        {
            DebitAccount debitAcc = client.FindDebitAccount(debitAccount);
            DepositAccount depositAcc = client.FindDepositAccount(depositAccount);
            client.SetMoney(client.GetMoney() + (client.GetBank().GetPersentage() / 100 * client.GetMoney()));
        }
    }
}