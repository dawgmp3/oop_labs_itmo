using System;
using Banks.Tools;

namespace Banks.Classes
{
    public class DebitAccount : Account
    {
        public DebitAccount(int money, int percent)
            : base(money)
        {
            int plusMoney = money * percent / 100;
        }

        public void OpenDebitAccount(Client client, int money)
        {
            client.SetDebitAccount(new DebitAccount(money, client.GetBank().GetPersentage()));
        }

        public override void GiveCommissionToAccount(Client client, CreditAccount creditAcc)
        {
            throw new BanksException("There are no commissions in Debit Account");
        }
    }
}