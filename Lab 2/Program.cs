using Lab_2;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Give feedback please!

            var products = Product.CreateProducts();

            List<Customer> customerLog = new List<Customer>();
            {
                customerLog.Add(new Customer("Knatte", "123"));
                customerLog.Add(new Customer("Fnatte", "321"));
                customerLog.Add(new Customer("Tjatte", "213"));
            }

            Menu shopMenu = new Menu();

            while (true)
            {

                shopMenu.ShopMenu();
                string customerInput = Console.ReadLine();

                if (customerInput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("   LOG IN   ");
                    Console.WriteLine("************");
                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();

                    Customer userLog = Customer.AuthenticateUser(username, password);

                    if (userLog != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome back {username}, you have logged in.");

                        while (true)
                        {
                            shopMenu.ShopOptionMenu();
                            customerInput = Console.ReadLine();

                            Product product = null;

                            if (customerInput == "1")
                            {

                                while (product == null)
                                {
                                    shopMenu.ProductMenu(products);

                                    int input = Convert.ToInt32(Console.ReadLine());

                                    products.TryGetValue(input, out product);

                                    if (input < 1 || input > 5)
                                    {
                                        Console.WriteLine("Pick between 1-6, press enter to continue.");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        userLog.cartAddProduct(product);
                                    }

                                }

                            }

                            else if (customerInput == "2")
                            {
                                userLog.CartDisplayTotal();
                            }

                            else if (customerInput == "3")
                            {
                                Console.WriteLine(userLog);
                            }

                            else if (customerInput == "4")
                            {
                                Console.WriteLine("Would you like to checkout? y/n");
                                customerInput = Console.ReadLine();

                                if (customerInput == "y")
                                {
                                    Console.WriteLine("Thank you for shopping at the simple console shop.");
                                    Environment.Exit(0);
                                }

                            }


                            else if (customerInput == "5")
                            {
                                Console.WriteLine("Thank you for shopping.");
                                break;
                            }
                        }
                    }
                    else if (userLog == null)
                    {
                        Console.WriteLine("Your username or password are incorrect.");
                        Console.WriteLine("Do you want to register? y/n");
                        customerInput = Console.ReadLine();
                        if (customerInput == "y")
                        {
                            Customer.RegisterCustomer(customerLog);
                        }
                        else
                        {
                            Console.WriteLine("Thank you for visiting!");
                            break;
                        }
                    }
                }

                else if (customerInput == "2")
                {
                    Customer.RegisterCustomer(customerLog);
                }

                else
                {
                    Console.WriteLine("Invalid input. Enter 1, 2 or 3.");
                }
            }
        }
    }
}