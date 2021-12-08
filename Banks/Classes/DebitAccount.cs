using System;
using Banks.Tools;

namespace Banks.Classes
{
    public class DebitAccount : Account
    {
        public DebitAccount(int money, int percent, Guid id, string isDoubtful, Bank bank)
            : base(money, id, isDoubtful, bank)
        {
        }
    }
}