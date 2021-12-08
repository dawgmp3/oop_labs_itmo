using System;
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
            Console.WriteLine("Would you like to add address?");
            string answer1 = Console.ReadLine();
            string address = string.Empty;
            if (answer1 == "yes" || answer1 == "Yes")
            {
                Console.WriteLine("What is your address?");
                address = Console.ReadLine();
            }
            else if (answer1 == "no" || answer1 == "No")
            {
                address = string.Empty;
            }

            string passport = string.Empty;
            Console.WriteLine("Would you like to add passport?");
            string answer2 = Console.ReadLine();
            if (answer2 == "yes" || answer2 == "Yes")
            {
                Console.WriteLine("What is your passport?");
                passport = Console.ReadLine();
            }
            else if (answer2 == "no" || answer2 == "No")
            {
                passport = string.Empty;
            }

            Client client = centralBank.CreateClient(name, surname, address, passport);
            bank.AddClient(client);
            Console.WriteLine("What kind of acc would you like to open?");
            Account account = null;
            string answer3 = Console.ReadLine();
            if (answer3 == "debit" || answer3 == "Debit")
            {
                Console.WriteLine("How much money would you ike to put in your acc?");
                int money = Convert.ToInt32(Console.ReadLine());
                account = bank.OpenDebitAccount(client, money);
            }

            if (answer3 == "deposit" || answer3 == "Deposit")
            {
                Console.WriteLine("How much money would you ike to put in your acc?");
                int money = Convert.ToInt32(Console.ReadLine());
                account = bank.OpenDepositAccount(client, money);
            }

            if (answer3 == "credit" || answer3 == "credit")
            {
                Console.WriteLine("How much money would you ike to borrow?");
                int money = Convert.ToInt32(Console.ReadLine());
                account = bank.OpenCreditAccount(client, money);
            }

            Console.WriteLine("Would you like to see how much money you'll have in a year?");
            string answer4 = Console.ReadLine();
            if (answer4 == "yes" || answer4 == "Yes")
            {
                Console.WriteLine(account.ToSeeHowMuchInSomeYears(bank, account, 1));
            }
        }
    }
}
