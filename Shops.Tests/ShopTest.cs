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
                _shopService1.AddProductToShop(product, shop, 100, 101);
            });
        }
        
        [Test]
        public void PriceRePrice()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            Product prodRegistr = _shopService1.ProductsRegistration("Milk", 10000);
            Product prod = _shopService1.AddProductToShop(prodRegistr, shop, 100, 100);
            shop.RePrice(prod, 101);
            Assert.AreEqual(101, prod.Price);
        }
        
        [Test]
        public void FindMinPrice()
        {
            Shop shop1 = _shopService1.AddShop("Tokko", "Kirova");
            Shop shop2 = _shopService1.AddShop("Almaz", "Yaroslavskogo");
            Shop shop3 = _shopService1.AddShop("Meow", "Kirova");
            Product prodRegistr = _shopService1.ProductsRegistration("Butter", 10000);
            _shopService1.AddProductToShop(prodRegistr, shop1, 99, 10);
            _shopService1.AddProductToShop(prodRegistr, shop2, 10, 10);
            _shopService1.AddProductToShop(prodRegistr, shop3, 100, 10);
            Product product = new Product("Butter");
            product.Amount = 2;
            List<Product> prd = new List<Product>();
            prd.Add(product);
            _shopService1.FindMinimumPriceShop(prd);
            Assert.AreEqual(shop2, shop2);
        }

        [Test]
        public void Pursache_ThrowException()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            Product milk = _shopService1.ProductsRegistration("Milk", 10000);
            Product butter = _shopService1.ProductsRegistration("Butter", 10000);
            Product banana = _shopService1.ProductsRegistration("Banana", 10000);
            Product prodMilk = new Product("Milk");
            prodMilk.Amount = 10;
            Product prodButter = new Product("Butter");
            prodButter.Amount = 6;
            Product prodBanana = new Product("Banana");
            prodBanana.Amount = 2;
            List<Product> bucket = new List<Product>();
            bucket.Add(prodMilk);
            bucket.Add(prodButter);
            bucket.Add(prodBanana);
            Customer customer = new Customer("Misha", 1);
            Product prod1 = _shopService1.AddProductToShop(milk, shop, 10, 10);
            Product prod2 = _shopService1.AddProductToShop(butter, shop, 10, 10);
            Product prod3 = _shopService1.AddProductToShop(banana, shop, 10, 10);
            Assert.Catch<ShopException>(() =>
            {
                _shopService1.Purchase(customer, shop, bucket);
            });
        }

        [Test]
        public void Delivery_AreEqual()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            Product milk = _shopService1.ProductsRegistration("Bread", 10000);
            Product prodBread = new Product("Bread");
            prodBread.Amount = 4;
            List<Product> bucket = new List<Product>();
            bucket.Add(prodBread);
            Customer customer = new Customer("Misha", 10000);
            Product prod1 = _shopService1.AddProductToShop(milk, shop, 10, 10);
            _shopService1.Purchase(customer, shop, bucket);
            Assert.AreEqual(4, customer.GetAmountOfCustomersProduct(prodBread));
        }
        [Test]
        public void AddProduct_Amount()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            _shopService1.ProductsRegistration("Milk", 1000); 
            Product product = new Product("Milk");
            _shopService1.AddProductToShop(product, shop, 100, 101);
            _shopService1.AddProductToShop(product, shop, 100, 2);
            Product p = shop.FindProduct(product, product.Amount);
            Assert.AreEqual(103, p.Amount);
        }
    }
}