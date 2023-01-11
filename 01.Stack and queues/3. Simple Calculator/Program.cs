using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(input.Reverse());
            int sum = int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                char sign = char.Parse(stack.Pop());
                if (sign == '+')
                {
                    sum += int.Parse(stack.Pop());
                }
                else
                {
                    sum -= int.Parse(stack.Pop());
                }
            }
            Console.WriteLine(sum);
        }
    }
}
