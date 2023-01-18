using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop][product] = price;
            }
            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
