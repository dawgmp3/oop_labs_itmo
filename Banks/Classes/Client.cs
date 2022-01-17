using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class Client
    {
        public Client(string name, string surname, string address, string passport, List<Account> accounts, Bank bank)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Passport = passport;
            BankClient = bank;
            Accounts = accounts;
        }

        public List<Account> Accounts { get; set; }

        public string Passport { get; set; }

        public Bank BankClient { get; set; }

        public string Address { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }
        public bool CheckIsDoubtful()
        {
            if (Passport != string.Empty && Address != string.Empty)
            {
                return true;
            }

            return false;
        }

        public ClientBuilder ToBuild()
        {
            ClientBuilder client = new ClientBuilder();
            client.WithName(Name)
                  .WithSurname(Surname)
                  .WithAddress(Address)
                  .WithPassport(Passport)
                  .WithAccount()
                  .WithBank(BankClient);
            return client;
        }

        public class ClientBuilder
        {
            private string _name;
            private string _surname;
            private string _address;
            private string _passport;
            private List<Account> _accounts;
            private Bank _bank;

            public ClientBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public ClientBuilder WithSurname(string surname)
            {
                _surname = surname;
                return this;
            }

            public ClientBuilder WithAddress(string address)
            {
                _address = address;
                return this;
            }

            public ClientBuilder WithPassport(string passport)
            {
                _passport = passport;
                return this;
            }

            public ClientBuilder WithAccount()
            {
                _accounts = new List<Account>();
                return this;
            }

            public ClientBuilder WithBank(Bank bank)
            {
                _bank = bank;
                return this;
            }

            public Client Build()
            {
                Client client = new Client(_name, _surname, _address, _passport, _accounts, _bank);
                return client;
            }
        }
    }
}