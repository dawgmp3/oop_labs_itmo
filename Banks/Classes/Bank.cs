using System;
using System.Collections.Generic;
using System.IO.Pipes;

namespace Banks.Classes
{
    public class Bank
    {
        private string _name;
        private string _statusOfCommission;
        private string _statusOfPercentage;
        private DateTime _dateOfCreation;
        private int _percentage;
        private int _commission;
        public Bank(string name)
        {
            _name = name;
            Clients = new List<Client>();
            _dateOfCreation = new DateTime(0);
            _percentage = 0;
            _commission = 0;
            _statusOfCommission = "No need for commissions this month";
            _statusOfPercentage = "No need for giving percentage";
        }

        public List<Client> Clients { get; }

        public void SetDayOfCreation()
        {
            _dateOfCreation = DateTime.Today;
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void ChangeStatusOfCommissions(string message)
        {
            _statusOfCommission = message;
        }

        public void SetPersentage(int percentage)
        {
            _percentage = percentage;
        }

        public int GetPersentage()
        {
            return _percentage;
        }

        public void SetCommission(int commission)
        {
            _commission = commission;
        }

        public void ChangeStatusOfPersentage(string message)
        {
            _statusOfPercentage = message;
        }
    }
}