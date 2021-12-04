using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank> _allBanks = new List<Bank>();
        public Bank BankRegistration(string name, int percentage, int comission)
        {
            Bank newBank = new Bank(name);
            newBank.SetPersentage(percentage);
            newBank.SetCommission(comission);
            newBank.SetDayOfCreation();
            _allBanks.Add(newBank);
            return newBank;
        }

        public void Notification()
        {
            string comission = "Pay comission";
            string paymentOfPercentage = "Pay percentage";
            foreach (var bank in _allBanks)
            {
                bank.ChangeStatusOfCommissions(comission);
                bank.ChangeStatusOfPersentage(paymentOfPercentage);
            }
        }
    }
}