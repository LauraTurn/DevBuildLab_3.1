using System;
using System.Collections.Generic;

namespace RevistLab3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> herbs = new Dictionary<string, decimal>();
            herbs.Add("anise", .99m);
            herbs.Add("basil", .59m);
            herbs.Add("comfrey", 1.59m);
            herbs.Add("dandelion", 2.19m);
            herbs.Add("elder", 1.79m);
            herbs.Add("fennel", 2.09m);
            herbs.Add("ginger", 1.99m);
            herbs.Add("honey", 2.09m);
            herbs.Add("lavender", 2.99m);
            herbs.Add("marigold", 3.99m);

            List<string> items = new List<string>();                //List of grocery items
            List<decimal> prices = new List<decimal>();             //List of grocery prices

            bool complete = false;
            while (!complete)
            {
                Console.WriteLine(String.Format("{0, 5}\t{1, 15}", "ITEM", "PRICE"));  //{Index Position, Spacing}  Aligns Headers
                Console.WriteLine(String.Format("========================"));
                foreach (var inventory in herbs)
                {
                    Console.WriteLine(inventory);
                }
                Console.Write("\nWhat item would you like to order? ");  //Asking the customer to order an item
                string user = Console.ReadLine().ToLower();
                if (herbs.ContainsKey(user) == false)
                {
                    Console.WriteLine($"Sorry, we don't have {user}");
                }
                else
                {
                    items.Add(user);
                    decimal cost = herbs[user];
                    prices.Add(cost);
                }

                bool over = false;
                while (!over)
                {
                    Console.Write("\nWould you like to order anything else? (y/n): ");
                    string reply = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if (reply == "n")
                    {
                        Console.WriteLine("Thanks for your order!");
                        over = true;
                        complete = true;
                    }
                    else if (reply == "y")
                    {
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response next time! (y/n)");
                        over = false;
                    }
                }
            }
                Console.WriteLine("Here's what you got: ");
                decimal totals = 0;
                for (int i = 0; i < items.Count; i++)       //Listing the items & their prices.  Setting initiating i.
                {
                    Console.WriteLine($"{items[i]} - {prices[i]}");
                    totals = totals + prices[i];
                    complete = true;
                }
                Console.WriteLine($"\nAverage price per item in your order is ${totals / items.Count:0.00}.");           
        }
    }
}
