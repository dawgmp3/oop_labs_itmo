using System;
using Banks.Tools;

namespace Banks.Classes
{
    public class DepositAccount : Account
    {
        private double percentage;
        public DepositAccount(int money, Guid id, string isDoubtful, Bank bank)
            : base(money, id, isDoubtful, bank)
        {
            percentage = 0;
        }

        public double CountPercentage(DepositAccount depositAccount)
        {
            if (depositAccount.GetMoney() < 50000)
            {
                percentage = 3;
            }

            if (depositAccount.GetMoney() >= 50000 && depositAccount.GetMoney() <= 100000)
            {
                percentage = 3.5;
            }

            return percentage;
        }

        public double GetPercentageOfAccount()
        {
            return percentage;
        }

        public override void WithdrawMoney(Bank bank, Account account, int money)
        {
            throw new BanksException("You can not withdraw money from deposit account");
        }

        public override void TransferMoneyToAnotherClient(Account clientSender, Account clientCatcher, int moneyToSend)
        {
            throw new BanksException("You can not send money to another client from deposit account");
        }
    }
}