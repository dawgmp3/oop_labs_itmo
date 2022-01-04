using System;
using System.Data;
using Banks.Classes;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            Bank bank = new Bank("Meow");
            CentralBank centralBank = new CentralBank();
            centralBank.BankRegistration(bank, 10, 10, 1000);
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What is your surname?");
            string surname = Console.ReadLine();
            Console.WriteLine("Would you like to add address? Write 'y' or 'n'");
            string answer1 = Console.ReadLine();
            string address = string.Empty;
            if (answer1 == "y")
            {
                Console.WriteLine("What is your address?");
                address = Console.ReadLine();
            }
            else if (answer1 == "n")
            {
                address = string.Empty;
            }

            string passport = string.Empty;
            Console.WriteLine("Would you like to add passport?");
            string answer2 = Console.ReadLine();
            if (answer2 == "y")
            {
                Console.WriteLine("What is your passport?");
                passport = Console.ReadLine();
            }
            else if (answer2 == "n")
            {
                passport = string.Empty;
            }

            Client client = bank.CreateClient(name, surname, address, passport);
            bank.AddClient(client);
            Console.WriteLine("What kind of acc would you like to open?");
            Account account = null;
            Account account1 = null;
            string answer3 = Console.ReadLine();
            if (answer3 == "debit" || answer3 == "Debit")
            {
                Console.WriteLine("How much money would you like to put in your acc?");
                int money = Convert.ToInt32(Console.ReadLine());
                account = bank.OpenDebitAccount(client, money);
            }

            if (answer3 == "deposit" || answer3 == "Deposit")
            {
                Console.WriteLine("How much money would you like to put in your acc?");
                int money = Convert.ToInt32(Console.ReadLine());
                account = bank.OpenDepositAccount(client, money);
            }

            if (answer3 == "credit" || answer3 == "credit")
            {
                Console.WriteLine("How much money would you like to borrow?");
                int money = Convert.ToInt32(Console.ReadLine());
                account = bank.OpenCreditAccount(client, money);
            }

            Console.WriteLine("Would you like to see how much money you'll have in a year?");
            string answer4 = Console.ReadLine();
            if (answer4 == "y")
            {
                Console.WriteLine(account.ToSeeHowMuchInSomeYears(bank, 1));
            }

            Console.WriteLine("Would you like to open second account?");
            string answer5 = Console.ReadLine();
            if (answer5 == "y")
            {
                Console.WriteLine("How much money would you like to put in your acc?");
                int money = Convert.ToInt32(Console.ReadLine());
                account1 = bank.OpenDebitAccount(client, money);
            }

            Console.WriteLine("Would you like to transfer money?");
            string answer6 = Console.ReadLine();
            if (answer6 == "y")
            {
                Console.WriteLine("How much?");
                int money = Convert.ToInt32(Console.ReadLine());
                account.TransferMoneyToAnotherClient(account, account1, money);
                int moneyInAcc = account1.GetMoney();
                Console.WriteLine(moneyInAcc);
            }

            Console.WriteLine("Would you like to withdraw money?");
            string answer7 = Console.ReadLine();
            if (answer7 == "y")
            {
                Console.WriteLine("How much?");
                int money = Convert.ToInt32(Console.ReadLine());
                account.WithdrawMoney(money);
                int moneyInAcc = account.GetMoney();
                Console.WriteLine(moneyInAcc);
            }
        }
    }
}
