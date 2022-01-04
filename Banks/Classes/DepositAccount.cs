using System;
using Banks.Tools;

namespace Banks.Classes
{
    public class DepositAccount : Account
    {
        private double percentage;
        public DepositAccount(int money, Bank bank, Client client)
            : base(money, bank, client)
        {
            BankAccount = bank;
        }

        public Bank BankAccount { get; set; }

        public double CountPercentage(DepositAccount depositAccount)
        {
            if (depositAccount.GetMoney() > BankAccount.GetHighLimitDepositAcc())
            {
                percentage = depositAccount.BankAccount.GetHighPercentageDepositAcc();
            }

            if (depositAccount.GetMoney() <= BankAccount.GetLowLimitDepositAcc())
            {
                percentage = depositAccount.BankAccount.GetLowPercentageDepositAcc();
            }

            return percentage;
        }

        public double GetPercentageOfAccount()
        {
            return percentage;
        }

        public override void WithdrawMoney(int money)
        {
            throw new BanksException("You can not withdraw money from deposit account");
        }

        public override Transaction TransferMoneyToAnotherClient(Account clientSender, Account clientCatcher, int moneyToSend)
        {
            throw new BanksException("You can not send money to another client from deposit account");
        }
    }
}