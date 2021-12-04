using Banks.Tools;

namespace Banks.Classes
{
    public class DepositAccount : Account
    {
        private double percentage;
        public DepositAccount(Client client, int money)
            : base(money)
        {
            percentage = 0;
        }

        public void OpenDepositAccount(Client client, int money)
        {
            if (money < 50000)
            {
                percentage = 3;
            }

            if (money >= 50000 && money <= 100000)
            {
                percentage = 3.5;
            }

            client.SetDepositAccount(new DepositAccount(client, money));
        }

        public double GetPercentageOfAccount()
        {
            return percentage;
        }

        public override void WithdrawMoney(Client client, int money)
        {
            throw new BanksException("You can not withdraw money from deposit account");
        }

        public override void WithdrawMoneyToAnotherClient(Client clientSender, Client clientCatcher, int moneyToSend)
        {
            throw new BanksException("You can not send money to another client from debit account");
        }

        public override void GiveCommissionToAccount(Client client, CreditAccount creditAcc)
        {
            throw new BanksException("There are no commissions in Deposit Account");
        }
    }
}