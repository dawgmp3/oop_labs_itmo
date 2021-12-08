using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class Client
    {
        private static string _name;
        private static string _surname;
        private static string _address;
        private static string _passport;
        private static Bank _bank;
        private static List<Account> _accounts;
        public Client(string name, string surname, string address, string passport, List<Account> accounts, Bank bank)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _passport = passport;
            _bank = bank;
            _accounts = accounts;
        }

        public static ClientBuilder ToBuild(ClientBuilder client)
        {
            client.WithName(_name)
                  .WithSurname(_surname)
                  .WithAddress(_address)
                  .WithPassport(_passport)
                  .WithAccount()
                  .WithBank(_bank);
            return client;
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public string GetAddress()
        {
            return _address;
        }

        public string GetPassport()
        {
            return _passport;
        }

        public void SetBank(Bank bank)
        {
            _bank = bank;
        }

        public Bank GetBank()
        {
            return _bank;
        }

        public List<Account> GetAccounts()
        {
            return _accounts;
        }

        public CreditAccount FindCreditAccount(CreditAccount account)
        {
            CreditAccount foundAccount = null;
            foreach (var acc in _accounts)
            {
                if (acc == account)
                {
                    foundAccount = (CreditAccount)acc;
                }
            }

            return foundAccount;
        }

        public DebitAccount FindDebitAccount(DebitAccount account)
        {
            DebitAccount foundAccount = null;
            foreach (var acc in _accounts)
            {
                if (acc == account)
                {
                    foundAccount = (DebitAccount)acc;
                }
            }

            return foundAccount;
        }

        public DepositAccount FindDepositAccount(DepositAccount account)
        {
            DepositAccount foundAccount = null;
            foreach (var acc in _accounts)
            {
                if (acc == account)
                {
                    foundAccount = (DepositAccount)acc;
                }
            }

            return foundAccount;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public void SetPassport(string passport)
        {
            _passport = passport;
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