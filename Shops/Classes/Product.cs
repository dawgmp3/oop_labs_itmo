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
            Id1 = Id();
        }

        public string Name { get; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public Guid Id1 { get; }
        private static Guid Id()
        {
            Guid id = Guid.NewGuid();
            return id;
        }
    }
}