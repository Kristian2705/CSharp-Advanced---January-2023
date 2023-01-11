using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
