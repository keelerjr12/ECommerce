using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using ECommerceDomain.Sales.Product;

namespace ECommerceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> inventory = new List<Product>()
            {
                new Product("jkh23jkasd", "Sony", "Sony 65\" TV", 915.99m),
                new Product("klaj32ioua", "Panasonic", "Panasonic 42\" HDTV", 415.99m),
            };
            var cart = new Cart();
            bool running = true;

            do
            {
                try
                {
                    var tokens = GetInput();
                    var command = tokens[0];

                    switch (command)
                    {
                        case "Menu":
                            Console.WriteLine("DisplayInventory");
                            Console.WriteLine("AddToCart [ProductId] [Quantity]");
                            Console.WriteLine("DisplayCart");
                            Console.WriteLine("Quit");
                            break;

                        case "Login":
                            var username = tokens[1];
                            var password = tokens[2];
                            break;

                        case "DisplayInventory":
                            for(var index = 0; index < inventory.Count; index++)
                            {
                                var product = inventory[index];
                                Console.WriteLine("{0}:\t{1}\t\t${2}", index, product.Description, product.Price);
                            }
                            break;

                        case "AddToCart":
                        {
                            var productId = int.Parse(tokens[1]);
                            var quantity = int.Parse(tokens[2]);
                            var product = inventory[productId];
                            cart.Add(product, Quantity.Is(quantity));
                        }
                            break;
                            
                        case "DisplayCart":
                        {
                            foreach (var item in cart.Items)
                            {
                                Console.WriteLine("{0}x{1}\t${2}", item.Quantity, item.Description, item.Price);
                            }

                            Console.WriteLine("Subtotal: ${0} ({1} items)", cart.Subtotal, cart.ItemCount);
                        }
                            break;


                        case "Quit":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input entered");
                            break;
                    }
                }
                catch (ArgumentNullException e)
                {
                    //TODO: Implement logging framework
                    Console.WriteLine(e);
                }

            } while (running);
  
        }

        private static List<string> GetInput()
        {
            Console.Write(">");

            var line = Console.ReadLine() ?? throw new NullReferenceException("Null console data");

            return line.Split(' ').ToList();
        }
    }
}
