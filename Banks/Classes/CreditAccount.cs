using System;
using Banks.Tools;

namespace Banks.Classes
{
    public class CreditAccount : Account
    {
        private int _amountOfMoneyToBorrow;
        private int _amountOfMoneyNeedToReturn;
        private string _isDoubtful;
        public CreditAccount(int money, Guid id, string isDoubtful, Bank bank)
            : base(money, id, isDoubtful, bank)
        {
            _amountOfMoneyToBorrow = money;
            _amountOfMoneyNeedToReturn = money;
            _isDoubtful = isDoubtful;
        }

        public int GetAmountOfBorrowedMoney()
        {
            return _amountOfMoneyToBorrow;
        }

        public int GetAmountOfMoneyNeedToReturn()
        {
            return _amountOfMoneyNeedToReturn;
        }

        public void SetAmountOfMoneyNeedToReturn(int money)
        {
            _amountOfMoneyNeedToReturn = money;
        }

        public void SetAmountOfMoneyToBorrow(int amountOfMoneyToBorrow)
        {
            _amountOfMoneyToBorrow = amountOfMoneyToBorrow;
        }

        public override void TransferMoneyToAnotherClient(Account accountSender, Account accountCatcher, int moneyToSend)
        {
            throw new BanksException("You can not withdraw money from credit acc");
        }

        public override int ToSeeHowMuchInSomeMonth(Bank bank, Account account, int amountOfMonth)
        {
            throw new BanksException("You can not count because it is credit acc");
        }

        public override int ToSeeHowMuchInSomeYears(Bank bank, Account account, int amountOfYears)
        {
            throw new BanksException("You can not count because it is credit acc");
        }
    }
}