﻿using System;
using System.Collections.Generic;

namespace _1.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
