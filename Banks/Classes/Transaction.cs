using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class Transaction
    {
        public Transaction(int amountOfMoney, Account catcherAccount, Account senderAccount)
        {
            AmountOfMoney = amountOfMoney;
            AccountCatcher = catcherAccount;
            AccountSender = senderAccount;
            Id = Guid.NewGuid();
            Status = true;
        }

        public bool Status { get; set; }

        public Account AccountSender { get; set; }

        public Account AccountCatcher { get; set; }

        public Guid Id { get; set; }

        public int AmountOfMoney { get; set; }
    }
}