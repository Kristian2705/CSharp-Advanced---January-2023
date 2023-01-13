using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
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
            Stack<int> stack = new Stack<int>(nums);
            for (int i = 0; i < cmd[1]; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            if (stack.Contains(cmd[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
