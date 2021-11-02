using System;
using System.Collections.Generic;

namespace Shops.Classes
{
    public class Shop
    {
        public Shop(string name, string adress)
        {
            Name = name;
            Adress = adress;
            Id_ = Guid2Int();
            Products_ = new List<Product>();
        }

        public List<Product> Products_ { get; }
        public string Name { get; }
        public string Adress { get; }
        public int Id_ { get; }
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