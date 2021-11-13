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

        public Shop AddShop(string name, string adress)
        {
            var shop = new Shop(name, adress);
            _shops.Add(shop);
            return shop;
        }

        public Product ProductsRegistration(string product, int amount)
        {
            foreach (Product storageProd in _storage.Where(storageProd => product == storageProd.Name))
            {
                storageProd.Amount += amount;
                return storageProd;
            }

            var prdct = new Product(product);
            prdct.Amount = amount;
            _storage.Add(prdct);
            return prdct;
        }

        public Product AddProduct(Product product, Shop shop, int price, int amount)
        {
            foreach (Product productInStorage in _storage)
            {
                if (product.Name == productInStorage.Name && productInStorage.Amount >= amount)
                {
                    Product prod = shop.FindProduct(product, amount);
                    if (prod != null)
                    {
                        prod.Amount += amount;
                        return prod;
                    }
                }
            }

            foreach (Product productInStorage in _storage)
            {
                if (product.Name == productInStorage.Name && productInStorage.Amount >= amount)
                {
                    var newProd = new Product(product.Name);
                    newProd.Amount = amount;
                    newProd.Price = price;
                    shop.AddProduct(newProd);
                    return newProd;
                }
            }

            throw new ShopException("No product in storage");
        }

        public Shop Purchase(Customer customer, Shop shop, int amount, List<Product> products)
        {
            int price = CountPrice(shop, products, amount);
            foreach (Product prod in products)
            {
                Product findedProd = shop.FindProduct(prod, amount);
                if (findedProd == null)
                {
                    throw new ShopException("No product in the shop");
                }

                if (customer.Wallet >= price)
                {
                    customer.Wallet -= price;
                }

                if (customer.Wallet < price)
                {
                    throw new ShopException("No money");
                }

                Delivery(customer, amount, products);
            }

            return shop;
        }

        public Shop FindMinimumPriceShop(Product product, int amount)
        {
            int min = int.MaxValue;
            Shop shopWithMinPrice = null;
            foreach (Shop shop in _shops)
            {
                int price = shop.FindPrice(product, amount);
                if (price < min)
                {
                    min = price;
                    shopWithMinPrice = shop;
                }
            }

            if (min != int.MaxValue && shopWithMinPrice != null)
            {
                return shopWithMinPrice;
            }

            throw new ShopException("Error");
        }

        public void Delivery(Customer customer, int amount, List<Product> products)
        {
            foreach (var productInBucket in products)
            {
                customer.AddProductToFridge(productInBucket, amount);
            }
        }

        public int CountPrice(Shop shop, List<Product> bucket, int amount)
        {
            int finalPriceOfBucket = 0;
            foreach (Product productInBucket in bucket)
            {
                int price = shop.FindPrice(productInBucket, amount) * amount;
                finalPriceOfBucket += price;
            }

            return finalPriceOfBucket;
        }
    }
}