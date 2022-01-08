using System.Collections.Generic;
using System.Linq;

namespace Shops.Classes
{
    public class Customer
    {
        public Customer(string name, int wallet)
        {
            Name = name;
            Wallet = wallet;
            Products = new List<Product>();
        }

        public List<Product> Products { get; }

        public string Name { get; }
        public int Wallet { get; set; }

        public void AddProductToCustomer(Product product, int amount)
        {
            Product newProduct = FindCustomersProduct(product);
            if (newProduct != null)
            {
                newProduct.Amount += amount;
            }
            else
            {
                Products.Add(product);
            }
        }

        public Product FindCustomersProduct(Product product)
        {
            return Products.FirstOrDefault(productInShop => product.Name == productInShop.Name);
        }

        public int GetAmountOfCustomersProduct(Product product)
        {
            int amount = 0;
            Product prod = Products.FirstOrDefault(customersProduct => product.Name == customersProduct.Name);
            if (prod != null)
            {
                amount = prod.Amount;
            }

            return amount;
        }
    }
}