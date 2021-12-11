using System;
using System.Dynamic;
using System.Security.Cryptography;

namespace Shops.Classes
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public string Name { get; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Guid Id { get; }
    }
}