using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Tools;

namespace Shops.Classes
{
    public class Shop
    {
        public Shop(string name, string address)
        {
            Name = name;
            Adress = address;
            Id = Guid.NewGuid();
            Products = new List<Product>();
        }

        public List<Product> Products { get; }

        public string Name { get; }
        public string Adress { get; }
        public Guid Id { get; }

        public bool FindProducts(List<Product> products)
        {
            int amountOfProducts = products.Count;
            int result = 0;
            foreach (var product in products)
            {
                if (FindProduct(product, product.Amount) != null)
                {
                    result += 1;
                }
            }

            if (result == amountOfProducts)
            {
                return true;
            }

            return false;
        }

        public Product FindProduct(Product product, int amount)
        {
            return Products.FirstOrDefault(productInShop => product.Name == productInShop.Name && productInShop.Amount >= amount);
        }

        public Product RePrice(Product product, int price)
        {
            Product productInShop = Products.FirstOrDefault(prduct => prduct.Name == product.Name);
            if (productInShop != null)
            {
                productInShop.Price = price;
                return productInShop;
            }

            throw new ShopException("No such product in shop");
        }

        public int FindPrice(List<Product> products)
        {
            int price = 0;
            foreach (var productInShop in Products)
            {
                foreach (var productForBuying in products)
                {
                    if (productForBuying.Name == productInShop.Name)
                    {
                        price += productInShop.Price * productForBuying.Amount;
                    }
                }
            }

            return price;
        }
    }
}
