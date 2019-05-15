
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using Newtonsoft.Json;
namespace Market
{
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int category { get; set; }

        public Product(int id, string name, double price, int category)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.category = category;
        }

        public Product()
        {

        }

        public override string ToString()
        {
            return $"{id},{name},{price},{category}";
        }
    }
}
