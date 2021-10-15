using System;
using System.Collections.Generic;
using Shops.Classes;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager : IShopManager
    {
        private List<Shop> _shops = new List<Shop>();
        private List<Products> _storage = new List<Products>();

        public Shop AddShop(string name, string adress)
        {
            var shop = new Shop(name, adress);
            _shops.Add(shop);
            return shop;
        }

        public Products ProductsRegistration(string product, int amount)
        {
            foreach (Products storageprod in _storage)
            {
                if (product == storageprod.Name)
                {
                    storageprod.Amount += amount;
                    return storageprod;
                }
            }

            var prdct = new Products(product);
            prdct.Amount = amount;
            _storage.Add(prdct);
            return prdct;
        }

        public Products AddProducts(Products product, Shop shop, int price, int amount)
        {
            foreach (Products productInStorage in _storage)
            {
                if (product.Name == productInStorage.Name && amount <= productInStorage.Amount)
                {
                    foreach (Products prod in shop.Products_)
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

            Products newProd = new Products(product.Name);
            newProd.Amount = amount;
            newProd.Price = price;
            shop.Products_.Add(newProd);
            return newProd;
        }

        public void RePrice(Products product, int price, Shop shop)
        {
            foreach (Products productInShop in shop.Products_)
            {
                if (product.Id1 == productInShop.Id1)
                {
                    productInShop.Price = price;
                }
            }
        }

        public Shop Purchase(Customer customer, Shop shop, string product, int amount)
        {
            foreach (Products productInShop in shop.Products_)
            {
                if (product == productInShop.Name)
                {
                    if (amount <= productInShop.Amount && customer.Wallet >= productInShop.Price * amount)
                    {
                        productInShop.Amount -= amount;
                        customer.Wallet -= productInShop.Price * amount;
                        return shop;
                    }
                }
            }

            throw new ShopException("There is no such a product in shop");
        }

        public int FindMinimumPrice(string productName, int amount)
        {
            int min = int.MaxValue;
            int shop = 0;
            foreach (var shopP in _shops)
            {
                foreach (Products prodInShop in shopP.Products_)
                {
                    if (prodInShop.Price < min && prodInShop.Amount <= amount && productName == prodInShop.Name)
                    {
                        min = prodInShop.Price;
                        shop = shopP.Id_;
                    }
                }
            }

            if (min != int.MaxValue && shop != 0)
            {
                return shop;
            }

            throw new ShopException("Error");
        }

        public Shop Delivery(Customer customer, int amount, string prodname)
        {
            int shop = FindMinimumPrice(prodname, amount);
            foreach (Shop shops in _shops)
            {
                if (shops.Id_ == shop)
                {
                    Purchase(customer, shops, prodname, amount);
                    return shops;
                }
            }

            throw new ShopException("error");
        }
    }
}