using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Max_and_Min_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                if (input[0] == "1")
                {
                    int x = int.Parse(input[1]);
                    stack.Push(x);
                }
                else if (input[0] == "2")
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }
                else if (input[0] == "3")
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else
                {
                    if (stack.Count != 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
