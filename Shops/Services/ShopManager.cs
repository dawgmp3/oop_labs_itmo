using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Classes;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private readonly List<Shop> _shops = new List<Shop>();
        private readonly List<Product> _storage = new List<Product>();

        public Shop AddShop(string name, string address)
        {
            var shop = new Shop(name, address);
            _shops.Add(shop);
            return shop;
        }

        public Product ProductsRegistration(string product, int amount)
        {
            Product storageProd = _storage.FirstOrDefault(storageProd => storageProd.Name == product);

            if (storageProd != null)
            {
                storageProd.Amount += amount;
                return storageProd;
            }

            var newProduct = new Product(product);
            _storage.Add(newProduct);
            newProduct.Amount = amount;
            return newProduct;
        }

        public Product AddProductToShop(Product product, Shop shop, int price, int amount)
        {
            if (_storage.FirstOrDefault(prodInStorage =>
                product.Name == prodInStorage.Name && prodInStorage.Amount >= amount) == null)
            {
                throw new ShopException("No product in storage");
            }

            if (shop.Products.Find(productInShop => productInShop.Name == product.Name) != null)
            {
                foreach (var prodInShop in shop.Products)
                {
                    if (prodInShop.Name == product.Name)
                    {
                        prodInShop.Amount += amount;
                        return product;
                    }
                }
            }

            var newProd = new Product(product.Name);
            newProd.Amount = amount;
            newProd.Price = price;
            shop.Products.Add(newProd);
            return newProd;
        }

        public Shop Purchase(Customer customer, Shop shop, List<Product> products)
        {
            if (!shop.FindProducts(products))
            {
                throw new ShopException("No product in the shop");
            }

            int price = shop.FindPrice(products);
            if (customer.Wallet >= price)
            {
                customer.Wallet -= price;
            }

            if (customer.Wallet < price)
            {
                throw new ShopException("No money");
            }

            Delivery(customer, products);

            return shop;
        }

        public Shop FindMinimumPriceShop(List<Product> products)
        {
            int price;
            int min = 0;
            foreach (var shop in _shops.Where(shop => shop.FindProducts(products)))
            {
                min = shop.FindPrice(products);
            }

            Shop shopWithMinPrice = null;
            foreach (var shop in _shops.Where(shop => shop.FindProducts(products)))
            {
                price = shop.FindPrice(products);
                if (price <= min)
                {
                    min = price;
                    shopWithMinPrice = shop;
                }
            }

            if (shopWithMinPrice != null)
            {
                return shopWithMinPrice;
            }

            throw new ShopException("Error");
        }

        public void Delivery(Customer customer, List<Product> products)
        {
            foreach (var productInBucket in products)
            {
                customer.AddProductToCustomer(productInBucket, productInBucket.Amount);
            }
        }
    }
}