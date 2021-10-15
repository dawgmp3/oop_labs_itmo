using System;
using System.Dynamic;
using System.Security.Cryptography;

namespace Shops.Classes
{
    public class Products
    {
        public Products(string name)
        {
            Name = name;
            Id1 = Guid2Int();
        }

        public string Name { get; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int Id1 { get; }
        private static Guid Id()
        {
            Guid id = Guid.NewGuid();
            return id;
        }

        private int Guid2Int()
        {
            byte[] b = Id().ToByteArray();
            int bint = BitConverter.ToInt32(b, 0);
            return bint;
        }
    }
}