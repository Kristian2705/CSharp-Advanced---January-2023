using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            double[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            foreach (var num in input)
            {
                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 1;
                    continue;
                }
                numbers[num]++;
            }
            foreach (KeyValuePair<double, int> pair in numbers)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
