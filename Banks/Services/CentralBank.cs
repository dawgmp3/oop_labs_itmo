using System;
using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank> _allBanks = new List<Bank>();
        public Bank BankRegistration(Bank bank, int percentage, int comission, int limit)
        {
            bank.SetPersentage(percentage);
            bank.SetCommission(comission);
            bank.SetLimit(limit);
            return bank;
        }

        public void CancelTransactionTransfer(Transaction transaction)
        {
            if (transaction.Status)
            {
                transaction.AccountSender.PutMoneyInAcc(transaction.AmountOfMoney);
                transaction.AccountCatcher.WithdrawMoney(transaction.AmountOfMoney);
                transaction.Status = false;
            }
        }

        public void CancelTransactionWithdraw(Transaction transaction)
        {
            if (transaction.Status)
            {
                transaction.AccountSender.PutMoneyInAcc(transaction.AmountOfMoney);
                transaction.Status = false;
            }
        }

        public void ChangePercentage(Bank bank, int percentage)
        {
            bank.SetPersentage(percentage);
        }

        public void ChangeLimits(Bank bank, int limit)
        {
            bank.SetLimit(limit);
        }
    }
}