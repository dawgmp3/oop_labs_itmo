using System;
using System.Collections.Generic;
using System.Linq;
using Shops.Classes;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private List<Shop> _shops = new List<Shop>();
        private List<Product> _storage = new List<Product>();

        public Shop AddShop(string name, string adress)
        {
            var shop = new Shop(name, adress);
            _shops.Add(shop);
            return shop;
        }

        public Product ProductsRegistration(string product, int amount)
        {
            foreach (var storageprod in _storage.Where(storageprod => product == storageprod.Name))
            {
                storageprod.Amount += amount;
                return storageprod;
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
                if (product.Name == productInStorage.Name && amount <= productInStorage.Amount)
                {
                    foreach (Product prod in shop.Products_)
                    {
                        if (product.Name == prod.Name)
                        {
                            prod.Amount += amount;
                            return prod;
                        }
                    }
                }
                else
                {
                    throw new ShopException("No product");
                }
            }

            Product newProd = new Product(product.Name);
            newProd.Amount = amount;
            newProd.Price = price;
            shop.Products_.Add(newProd);
            return newProd;
        }

        public void RePrice(Product product, int price, Shop shop)
        {
            foreach (Product productInShop in shop.Products_)
            {
                if (product.Id1 == productInShop.Id1)
                {
                    productInShop.Price = price;
                }
            }
        }

        public Shop Purchase(Customer customer, Shop shop, int amount, List<Product> products)
        {
            List<Product> bucketOfBroducts = products;
            foreach (Product productInShop in shop.Products_)
            {
                foreach (var productInBucket in bucketOfBroducts)
                {
                    if (productInBucket.Name == productInShop.Name)
                    {
                        if (amount <= productInShop.Amount && customer.Wallet >= productInShop.Price * amount)
                        {
                            productInShop.Amount -= amount;
                            customer.Wallet -= productInShop.Price * amount;
                            return shop;
                        }
                    }
                }
            }

            throw new ShopException("There is no such a product in shop");
        }

        public Shop FindMinimumPriceShop(Product product, int amount)
        {
            int min = int.MaxValue;
            Shop shop = null;
            foreach (var shop_ in _shops)
            {
                foreach (Product prodInShop in shop_.Products_)
                {
                    if (prodInShop.Price < min && prodInShop.Amount <= amount && product.Id1 == prodInShop.Id1)
                    {
                        min = prodInShop.Price;
                        shop = shop_;
                    }
                }
            }

            if (min != int.MaxValue && shop != null)
            {
                return shop;
            }

            throw new ShopException("Error");
        }

        public Shop Delivery(Customer customer, int amount, List<Product> products)
        {
            Shop shop = null;
            foreach (var productInBucket in products)
            {
                shop = FindMinimumPriceShop(productInBucket, amount);
            }

            foreach (Shop shops in _shops)
            {
                if (shops.Name == shop.Name)
                {
                    Purchase(customer, shops, amount, products);
                    return shops;
                }
            }

            throw new ShopException("error");
        }
    }
}