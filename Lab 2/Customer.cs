using Lab_2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_2
{
    internal class Customer
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public List<Product> Cart { get; private set; }

        private static List<Customer> _user = new List<Customer>();

        public Customer(string username, string password)
        {
            Username = username;
            Password = password;
            Cart = new List<Product>();
            _user.Add(this);
        }

        public void addUser(string username, string password)
        {
            _user.Add(new Customer(username, password));
        }

        /*
        method that uses managementauthentication method that allows us
        to validate a users credentials in less code and also the find method
        that helps us match the users input with help of the authentication method
        */

        public static Customer AuthenticateUser(string username, string password)
        {
            return _user.Find(u => u.Username == username && u.Password == password);
        }

        public override string ToString()
        {
            return $"Customer: {Username} \nPassword: {Password} \nCart total: {GetTotal()}";
        }

        public static void RegisterCustomer(List<Customer> customers)
        {
            Console.WriteLine("Registering new user");
            Console.WriteLine("********************");
            Console.WriteLine("Enter in your desired username");
            string newUser = Console.ReadLine();
            Console.WriteLine("Enter in your desired password");
            string newPassword = Console.ReadLine();

            customers.Add(new Customer(newUser, newPassword));

            Console.WriteLine("You have registered.");
        }

        private double GetTotal()
        {
            double cartTotal = 0;

            foreach (var product in Cart)
            {
                cartTotal += product.Price;
            }

            return cartTotal;
        }

        public double CartDisplayTotal()
        {
            double totalCart = GetTotal();

            Console.Clear();
            Console.WriteLine($"{Username}'s cart contents: ");
            foreach (var product in Cart)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine($"The total cost of the cart is: {totalCart}");

            return totalCart;
        }

        public void cartAddProduct(Product product)
        {
            if (product.Quantity < 1)
            {
                Console.WriteLine($"There is no {product.Name} left.");
                return;
            }

            bool found = false;

            for (int i = 0; i < Cart.Count; i++)
            {
                if (Cart[i].Name == product.Name)
                {
                    Cart[i].Quantity++;

                    found = true;
                }
            }
            if (!found)
            {
                Product cartProduct = new Product(product.Name, 1, product.Price);
                Cart.Add(cartProduct);
            }
            product.Quantity--;
            Console.WriteLine("Successfully added to cart.");
        }

    }
}
