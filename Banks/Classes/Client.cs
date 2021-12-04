using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public class Client
    {
        private static string _name;
        private static string _surname;
        private static string _address;
        private static int _passport;
        private static Guid _id;
        private static int _money;
        private static Bank _bank;
        private static List<Account> _accounts;
        public Client(string name, string surname, string address, int passport, Guid id, List<Account> accounts, int money, Bank bank)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _passport = passport;
            _id = id;
            _money = money;
            _bank = bank;
            _accounts = accounts;
        }

        public static ClientBuilder ToBuild(ClientBuilder client)
        {
            client.WithName(_name)
                .WithSurname(_surname)
                .WithAddress(_address)
                .WithPassport(_passport)
                .WithId(_id)
                .WithAccount(_accounts)
                .WithBank(_bank);
            return client;
        }

        public void SetCreditAccount(CreditAccount account)
        {
            _accounts.Add(account);
        }

        public void SetDebitAccount(DebitAccount account)
        {
            _accounts.Add(account);
        }

        public void SetDepositAccount(DepositAccount account)
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

        public int GetPassport()
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

        public Guid GetId()
        {
            return _id;
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

        public int GetMoney()
        {
            return _money;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public void SetPassport(int passport)
        {
            _passport = passport;
        }

        public void SetMoney(int money)
        {
            _money = money;
        }

        public class ClientBuilder
        {
            private string _name;
            private string _surname;
            private string _address;
            private int _passport;
            private Guid _id;
            private int _money;
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

            public ClientBuilder WithPassport(int passport)
            {
                _passport = passport;
                return this;
            }

            public ClientBuilder WithId(Guid id)
            {
                _id = id;
                return this;
            }

            public ClientBuilder WithAccount(List<Account> account)
            {
                _accounts = account;
                return this;
            }

            public ClientBuilder WithMoney(int money)
            {
                _money = money;
                return this;
            }

            public ClientBuilder WithBank(Bank bank)
            {
                _bank = bank;
                return this;
            }

            public Client Build()
            {
                Client client = new Client(_name, _surname, _address, _passport, _id, _accounts, _money, _bank);
                return client;
            }
        }
    }
}