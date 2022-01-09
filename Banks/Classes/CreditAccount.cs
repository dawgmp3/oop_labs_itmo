using System;
using Banks.Tools;

namespace Banks.Classes
{
    public class CreditAccount : Account
    {
        public CreditAccount(int money, Bank bank, Client client)
            : base(money, bank, client)
        {
            AmountOfMoneyToBorrow = money;
            AmountOfMoneyNeedToReturn = money;
        }

        public int AmountOfMoneyNeedToReturn { get; set; }

        public int AmountOfMoneyToBorrow { get; set; }
        public override void WithdrawMoney(int money)
        {
            GetBank().GiveCommissionToCreditAccount(this);
        }

        public override Transaction TransferMoneyToAnotherClient(Account accountCatcher, int moneyToSend)
        {
            throw new BanksException("You can not withdraw money from credit acc");
        }

        public override int ToSeeHowMuchInSomeMonths(Bank bank, int amountOfMonth)
        {
            throw new BanksException("You can not count because it is credit acc");
        }

        public override int ToSeeHowMuchInSomeYears(Bank bank, int amountOfYears)
        {
            throw new BanksException("You can not count because it is credit acc");
        }
    }
}