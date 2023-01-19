using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 3. Periodic Table
            HashSet<string> chemicalCompounds = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var element in input)
                {
                    chemicalCompounds.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ", chemicalCompounds.OrderBy(x => x)));
        }
    }
}
