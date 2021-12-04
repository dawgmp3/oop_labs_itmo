namespace Banks.Classes
{
    public class CreditAccount : Account
    {
        private int _amountOfMoneyToBorrow;
        private int _amounOfMoneyNeedToReturn;
        public CreditAccount(int money)
            : base(money)
        {
            _amountOfMoneyToBorrow = money;
            _amounOfMoneyNeedToReturn = money;
        }

        public int GetAmountOfBorrowedMoney()
        {
            return _amountOfMoneyToBorrow;
        }

        public int GetAmountOfMoneyNeedToReturn()
        {
            return _amounOfMoneyNeedToReturn;
        }

        public void SetAmountOfMoneyNeedToReturn(int money)
        {
            _amounOfMoneyNeedToReturn = money;
        }

        public void OpenCreditAccount(Client client, int amountOfMoneyToBorrow)
        {
            client.SetMoney(client.GetMoney() + amountOfMoneyToBorrow);
            SetAmountOfMoneyToBorrow(amountOfMoneyToBorrow);
            client.SetCreditAccount(new CreditAccount(amountOfMoneyToBorrow));
        }

        public void SetAmountOfMoneyToBorrow(int amountOfMoneyToBorrow)
        {
            _amountOfMoneyToBorrow = amountOfMoneyToBorrow;
        }
    }
}