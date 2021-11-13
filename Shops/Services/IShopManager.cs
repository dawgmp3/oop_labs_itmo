using System.Collections.Generic;
using Shops.Classes;

namespace Shops.Services
{
    public interface IShopManager
    {
        Shop AddShop(string name, string adress);
        Product ProductsRegistration(string product, int amount);
        Product AddProduct(Product product, Shop shop, int price, int amount);
        Shop Purchase(Customer customer, Shop shop, int amount, List<Product> products);
        Shop FindMinimumPriceShop(Product product, int amount);
        void Delivery(Customer customer, int amount, List<Product> products);
        int CountPrice(Shop shop, List<Product> bucket, int amount);
    }
}