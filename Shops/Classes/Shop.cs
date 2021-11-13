using System;
using System.Collections.Generic;
using Shops.Tools;

namespace Shops.Classes
{
    public class Shop
    {
        private static List<Product> _products;
        public Shop(string name, string adress)
        {
            Name = name;
            Adress = adress;
            Id = GenerateId();
            _products = new List<Product>();
        }

        public string Name { get; }
        public string Adress { get; }
        public Guid Id { get; }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product FindProduct(Product product, int amount)
        {
            foreach (Product productInShop in _products)
            {
                if (product.Name == productInShop.Name && productInShop.Amount >= amount)
                {
                    return productInShop;
                }
            }

            return null;
        }

        public Product RePrice(Product product, int price)
        {
            foreach (var productInShop in _products)
            {
                if (productInShop.Name == product.Name)
                {
                    productInShop.Price = price;
                    return productInShop;
                }
            }

            throw new ShopException("No such product in shop");
        }

        public int FindPrice(Product product, int amount)
        {
            int price = 0;
            foreach (var productInShop in _products)
            {
                if (product.Name == productInShop.Name && productInShop.Amount >= amount)
                {
                    price = productInShop.Price;
                    return price;
                }
            }

            throw new ShopException("No such product in shop");
        }

        private Guid GenerateId()
        {
            Guid id = Guid.NewGuid();
            return id;
        }
    }
}