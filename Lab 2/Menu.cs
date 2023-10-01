using Lab_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class Menu
    {
        /*Menu class to declutter my main program*/

        public void ShopMenu()
        {
            Console.WriteLine("Simple console shop!");
            Console.WriteLine("*******************");
            Console.WriteLine("[1] - Log in");
            Console.WriteLine("[2] - Register");
            Console.WriteLine("[3] - Exit");
        }

        public void ShopOptionMenu()
        {
            Console.WriteLine($"Simple Console shop!");
            Console.WriteLine("*******************");
            Console.WriteLine("[1] - Shop");
            Console.WriteLine("[2] - View cart");
            Console.WriteLine("[3] - View customer info");
            Console.WriteLine("[4] - Checkout");
            Console.WriteLine("[5] - Sign out");
        }

        public void ProductMenu(Dictionary<int, Product> products)
        {
            Console.WriteLine("Simple console shop products!");
            Console.WriteLine("****************************");

            foreach (var product in products)
            {
                Console.WriteLine($"{product}");
            }
        }
    }
}
