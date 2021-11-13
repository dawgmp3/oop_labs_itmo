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
            shop.RePrice(prod, 101);
            Assert.AreEqual(101, prod.Price);
        }
        
        [Test]
        public void MinPrice_ThrowException()
        {
            Shop shop1 = _shopService1.AddShop("Tokko", "Kirova");
            Shop shop2 = _shopService1.AddShop("Almaz", "Yaroslavskogo");
            Shop shop3 = _shopService1.AddShop("Meow", "Kirova");
            Product prodRegistr = _shopService1.ProductsRegistration("Butter", 10000);
            Product product1 = _shopService1.AddProduct(prodRegistr, shop1, 99, 10);
            Product product2 = _shopService1.AddProduct(prodRegistr, shop2, 100, 10);
            Product product3 = _shopService1.AddProduct(prodRegistr, shop3, 10, 10);
            Product productt = new Product("Butter");
            Shop shopp = _shopService1.FindMinimumPriceShop(productt, 11);
            Assert.AreEqual(shop3, shop3);
        }

        [Test]
        public void Pursache_ThrowException()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            Product milk = _shopService1.ProductsRegistration("Milk", 10000);
            Product butter = _shopService1.ProductsRegistration("Butter", 10000);
            Product banana = _shopService1.ProductsRegistration("Banana", 10000);
            Product prodMilk = new Product("Milk");
            Product prodButter = new Product("Butter");
            Product prodBanana = new Product("Banana");
            List<Product> bucket = new List<Product>();
            bucket.Add(prodMilk);
            bucket.Add(prodButter);
            bucket.Add(prodBanana);
            Customer customer = new Customer("Misha", 1);
            Product prod1 = _shopService1.AddProduct(milk, shop, 10, 10);
            Product prod2 = _shopService1.AddProduct(butter, shop, 10, 10);
            Product prod3 = _shopService1.AddProduct(banana, shop, 10, 10);
            Assert.Catch<ShopException>(() =>
            {
                _shopService1.Purchase(customer, shop, 9, bucket);
            });
        }

        [Test]
            public void Delivery_AreEqual()
            {
                Shop shop = _shopService1.AddShop("Tokko", "Kirova");
                Product milk = _shopService1.ProductsRegistration("Milk", 10000);
                Product prodMilk = new Product("Milk");
                List<Product> bucket = new List<Product>();
                bucket.Add(prodMilk);
                Customer customer = new Customer("Misha", 10000);
                Product prod1 = _shopService1.AddProduct(milk, shop, 10, 10);
                _shopService1.Purchase(customer, shop, 1, bucket);
                _shopService1.Purchase(customer, shop, 5, bucket);
                Assert.AreEqual(6, customer.GetAmountOfProductInFridge(prodMilk));
            }
    }
}