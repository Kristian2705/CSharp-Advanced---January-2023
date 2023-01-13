using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            stack.Push("");
            for (int i = 0; i < n; i++)
            {
                string[] cmdTokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdTokens[0] == "1")
                {
                    string someStr = cmdTokens[1];
                    sb.Append(someStr);
                    stack.Push(sb.ToString());
                }
                else if (cmdTokens[0] == "2")
                {
                    int count = int.Parse(cmdTokens[1]);
                    string newSb = sb.ToString().Remove(sb.Length - count);
                    sb.Clear();
                    sb.Append(newSb);
                    stack.Push(sb.ToString());
                }
                else if (cmdTokens[0] == "3")
                {
                    int index = int.Parse(cmdTokens[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else
                {
                    if (sb.ToString() == stack.Peek())
                    {
                        stack.Pop();
                    }
                    sb.Clear();
                    sb.Append(stack.Pop());
                }
            }
        }
    }
}
