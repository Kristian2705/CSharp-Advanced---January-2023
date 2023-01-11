using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int n = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int totalCars = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Count != 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            totalCars++;
                        }
                    }
                }
            }
            Console.WriteLine($"{totalCars} cars passed the crossroads.");
        }
    }
}
