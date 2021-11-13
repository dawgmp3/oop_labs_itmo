using System.Collections.Generic;

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

        public void AddProductToFridge(Product product, int amount)
        {
            Product newProduct = FindProductInFridge(product);
            if (newProduct != null)
            {
                newProduct.Amount += amount;
            }
            else
            {
                Products.Add(product);
                AddProductToFridge(product, amount);
            }
        }

        public Product FindProductInFridge(Product product)
        {
            foreach (Product productInShop in Products)
            {
                if (product.Name == productInShop.Name)
                {
                    return productInShop;
                }
            }

            return null;
        }

        public int GetAmountOfProductInFridge(Product product)
        {
            int amount = 0;
            foreach (var productInFridge in Products)
            {
                if (product.Name == productInFridge.Name)
                {
                    amount = productInFridge.Amount;
                }
            }

            return amount;
        }
    }
}