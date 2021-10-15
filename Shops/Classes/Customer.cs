namespace Shops.Classes
{
    public class Customer
    {
        public Customer(string name, int wallet)
        {
            Name = name;
            Wallet = wallet;
        }

        public string Name { get; }
        public int Wallet { get; set; }
    }
}