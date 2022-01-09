using System.Collections.Generic;
using Shops.Classes;

namespace Shops.Services
{
    public interface IShopManager
    {
        Shop AddShop(string name, string adress);
        Product ProductsRegistration(string product, int amount);
        Product AddProductToShop(Product product, Shop shop, int price, int amount);
        Shop Purchase(Customer customer, Shop shop, List<Product> products);
        Shop FindMinimumPriceShop(List<Product> product);
        void Delivery(Customer customer, List<Product> products);
    }
}