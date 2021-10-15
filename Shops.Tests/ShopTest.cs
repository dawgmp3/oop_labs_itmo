using System;
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
            Assert.Catch<ShopException>(() =>
            {
                Shop shop = _shopService1.AddShop("Tokko", "Kirova");
                Products prodRegistr = _shopService1.ProductsRegistration("Milk", 100); 
                Products product = new Products("Milk");
                _shopService1.AddProducts(product, shop, 100, 101);
            });
        }
        
        [Test]
        public void Price_RePrice_ThrowException()
        {
            Shop shop = _shopService1.AddShop("Tokko", "Kirova");
            Products prodRegistr = _shopService1.ProductsRegistration("Milk", 10000);
            Products prod = _shopService1.AddProducts(prodRegistr, shop, 100, 100);
            _shopService1.RePrice(prod, 101, shop);
            Assert.AreEqual(101, prod.Price);
        }
        
        [Test]
        public void MinPrice_ThrowException()
        {
            Assert.Catch<ShopException>(() =>
            {
                Shop shop1 = _shopService1.AddShop("Tokko", "Kirova");
                Shop shop2 = _shopService1.AddShop("Almaz", "Yaroslavskogo");
                Products prodRegistr = _shopService1.ProductsRegistration("Butter", 10000);
                Products product1 = _shopService1.AddProducts(prodRegistr, shop1, 100, 10);
                Products product2 = _shopService1.AddProducts(prodRegistr, shop2, 99, 10);
                _shopService1.FindMinimumPrice("avocado", 11);
            });
        }
        
        [Test]
        public void Pursache_ThrowException()
        {
            Assert.Catch<ShopException>(() =>
            {
                Shop shop = _shopService1.AddShop("Tokko", "Kirova");
                Products prodRegistr = _shopService1.ProductsRegistration("Milk", 10000);
                Customer customer = new Customer("Misha", 10000000);
                Products prod1 = _shopService1.AddProducts(prodRegistr, shop, 100, 100);
                _shopService1.Purchase(customer, shop, "cat", 10);
            });
        }
    }
}