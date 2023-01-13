using System;
using System.Collections.Generic;

namespace _8._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string parentheses = Console.ReadLine();
            foreach (var p in parentheses)
            {
                if (p == '(' || p == '{' || p == '[')
                {
                    stack.Push(p);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    if ((stack.Peek() == '(' && p != ')') || (stack.Peek() == '[' && p != ']') || (stack.Peek() == '{' && p != '}'))
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    stack.Pop();
                }
            }
            if (stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
