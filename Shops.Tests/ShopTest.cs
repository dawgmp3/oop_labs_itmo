using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shops.Classes;
using Shops.Services;
using Shops.Tools;

namespace Shops.Tests
{
    public class ShopTest
    {
        private IShopManager _shopService1;
        
        [SetUp]
        public void Setup()
        {
            _shopService1 = new ShopManager();
        }

        [Test]
        public void AddProduct_ThrowException()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            Product prodRegistr = _shopService1.ProductsRegistration("Milk", 100); 
            Product product = new Product("Milk");
            Assert.Catch<ShopException>(() =>
            {
                _shopService1.AddProduct(product, shop, 100, 101);
            });
        }
        
        [Test]
        public void Price_RePrice_ThrowException()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            Product prodRegistr = _shopService1.ProductsRegistration("Milk", 10000);
            Product prod = _shopService1.AddProduct(prodRegistr, shop, 100, 100);
            _shopService1.RePrice(prod, 101, shop);
            Assert.AreEqual(101, prod.Price);
        }
        
        [Test]
        public void MinPrice_ThrowException()
        {
            Shop shop1 = _shopService1.AddShop("Tokko", "Kirova");
            Shop shop2 = _shopService1.AddShop("Almaz", "Yaroslavskogo");
            Product prodRegistr = _shopService1.ProductsRegistration("Butter", 10000);
            Product product1 = _shopService1.AddProduct(prodRegistr, shop1, 100, 10);
            Product product2 = _shopService1.AddProduct(prodRegistr, shop2, 99, 10);
            Assert.Catch<ShopException>(() =>
            {
                _shopService1.FindMinimumPriceShop(prodRegistr, 11);
            });
        }
        
        [Test]
        public void Pursache_ThrowException()
        {
            Assert.Catch<ShopException>(() =>
            {
                Shop shop = _shopService1.AddShop("Tokko", "Kirova");
                Product prodRegistr = _shopService1.ProductsRegistration("Milk", 10000);
                Product prodRegistr1 = _shopService1.ProductsRegistration("Milkq", 10000);
                List<Product> prod = new List<Product>();
                prod.Add(prodRegistr1);
                Customer customer = new Customer("Misha", 10000000);
                Product prod1 = _shopService1.AddProduct(prodRegistr, shop, 100, 100);
                _shopService1.Purchase(customer, shop, 10, prod);
            });
        }
    }
}