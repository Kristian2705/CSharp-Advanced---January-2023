using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 2. Sets of Elements
            HashSet<double> set1 = new HashSet<double>();
            HashSet<double> set2 = new HashSet<double>();
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < input[0]; i++)
            {
                set1.Add(double.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < input[1]; i++)
            {
                set2.Add(double.Parse(Console.ReadLine()));
            }
            List<double> repeatedNums = set1.Intersect(set2).ToList();
            Console.WriteLine(string.Join(" ", repeatedNums));
        }
    }
}
