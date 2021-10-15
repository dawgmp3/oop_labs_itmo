using Shops.Classes;

namespace Shops.Services
{
    public interface IShopManager
    {
        Shop AddShop(string name, string adress);
        Products ProductsRegistration(string product, int amount);
        Products AddProducts(Products product, Shop shop, int price, int amount);
        void RePrice(Products product, int price, Shop shop);
        Shop Purchase(Customer customer, Shop shop, string product, int amount);
        int FindMinimumPrice(string productName, int amount);
        Shop Delivery(Customer customer, int amount, string product);
    }
}