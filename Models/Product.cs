using System;

namespace web.Models
{
    public class Product
    {
        public String Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public static Product[] GetProducts()
        {
            Product bongro = new Product
            {
                Name = "bong ro",
                Price = 101
            };
            Product bongchuyen = new Product
            {
                Name = "bong chuyen",
                Price = 130
            };
            bongro.Related = bongchuyen;
            Product[] arrayProduct = new Product[] { bongro, bongchuyen, null };
            return arrayProduct;
        }
    }
}
