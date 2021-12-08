using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class CentralBank
    {
        private List<Bank> _allBanks = new List<Bank>();
        private List<Client> _doubtfulClients = new List<Client>();
        public Bank BankRegistration(Bank bank, int percentage, int comission, int limit)
        {
            bank.SetPersentage(percentage);
            bank.SetCommission(comission);
            bank.SetLimit(limit);
            return bank;
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

        public Client CreateClient(string name, string surname, string address = "", string passport = "")
        {
            var builder = new Client.ClientBuilder();
            Client.ClientBuilder clientToBuild = Client.ToBuild(builder);
            clientToBuild.WithName(name)
                .WithSurname(surname)
                .WithAddress(address)
                .WithPassport(passport)
                .WithAccount();
            Client newClient = clientToBuild.Build();
            _doubtfulClients.Add(newClient);
            return newClient;
        }

        public int CheckDoubtfulClient(Client client)
        {
            int check = 0;
            if (_doubtfulClients.Contains(client))
            {
                check = 1;
            }

            return check;
        }

        public void AddClientAddress(Client client, string address)
        {
            client.SetAddress(address);
        }

        public void AddClientPassport(Client client, string passport)
        {
            client.SetPassport(passport);
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