using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            string input = Console.ReadLine();
            int curr_index = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    int start_index = stack.Pop();
                    curr_index = i;
                    Console.WriteLine(input.Substring(start_index, curr_index - start_index + 1));
                }
            }
        }
    }
}
