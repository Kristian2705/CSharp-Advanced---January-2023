using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cmd = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(nums);
            for (int i = 0; i < cmd[1]; i++)
            {
                if (queue.Count != 0)
                {
                    queue.Dequeue();
                }
            }
            if (queue.Contains(cmd[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
