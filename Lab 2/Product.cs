using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double TotalPrice => Quantity * Price;

        public Product(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public static Dictionary<int, Product> CreateProducts()
        {
            var product = new Dictionary<int, Product>();
            product.Add(1, new Product("Crepe", 5, 50));
            product.Add(2, new Product("Fries", 10, 25));
            product.Add(3, new Product("Salad", 30, 23));
            product.Add(4, new Product("Hamburger", 20, 530));
            product.Add(5, new Product("Burger bun", 100, 150));

            return product;
        }

        public override string ToString()
        {
            return $"Product: {Name} Quantity: {Quantity} Price: {Price} Total price: {TotalPrice}";
        }
    }
}
