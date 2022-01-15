using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CancelTransactionTransfer(Transaction transaction, Bank bank)
        {
            Transaction transactionToCancell = bank.GetTransactions()
                .FirstOrDefault(transactionInBank => transactionInBank.Id == transaction.Id);
            if (transactionToCancell != null && transaction.Status)
            {
                transactionToCancell.AccountSender.PutMoneyInAcc(transaction.AmountOfMoney);
                transactionToCancell.AccountCatcher.WithdrawMoney(transaction.AmountOfMoney);
                transactionToCancell.Status = false;
            }
        }

        public void CancelTransactionWithdraw(Transaction transaction, Bank bank)
        {
            Transaction transactionToCancell = bank.GetTransactions()
                .FirstOrDefault(transactionInBank => transactionInBank.Id == transaction.Id);
            if (transactionToCancell != null && transaction.Status)
            {
                transactionToCancell.AccountSender.PutMoneyInAcc(transaction.AmountOfMoney);
                transactionToCancell.Status = false;
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