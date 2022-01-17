using System;
using Banks.Tools;

namespace Banks.Classes
{
    public class DebitAccount : Account
    {
        public DebitAccount(int money, Bank bank, Client client)
            : base(money, bank, client)
        {
            AmountOfMoney = money;
            BankOfAccount = bank;
            ClientOfAccount = client;
        }

        public Client ClientOfAccount { get; set; }

        public Bank BankOfAccount { get; set; }

        public int AmountOfMoney { get; set; }
    }
}