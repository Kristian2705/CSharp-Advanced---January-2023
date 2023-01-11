using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            Stack<int> stack = new Stack<int>(arr);
            string input = string.Empty;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdTokens = input.Split();
                string command = cmdTokens[0].ToLower();
                if (command == "add")
                {
                    int n1 = int.Parse(cmdTokens[1]);
                    int n2 = int.Parse(cmdTokens[2]);
                    stack.Push(n1);
                    stack.Push(n2);
                }
                else
                {
                    int count = int.Parse(cmdTokens[1]);
                    if (stack.Count - count <= 0)
                    {
                        continue;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        stack.Pop();
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
