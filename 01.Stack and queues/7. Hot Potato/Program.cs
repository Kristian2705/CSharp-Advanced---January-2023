using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine()
                .Split());
            int tosses = int.Parse(Console.ReadLine());
            while (queue.Count != 0)
            {
                for (int i = 0; i < tosses - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                if (queue.Count == 1)
                {
                    Console.WriteLine($"Last is {queue.Dequeue()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
            }
        }
    }
}
