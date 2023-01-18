using System;
using System.Collections.Generic;

namespace _2.AvrStudntGr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (!studentGrades.ContainsKey(input[0]))
                {
                    studentGrades[input[0]] = new List<decimal>();
                }
                studentGrades[input[0]].Add(decimal.Parse(input[1]));
            }
            foreach (var kvp in studentGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value.Select(x => $"{x:F2}").ToList())} (avg: {kvp.Value.Average():F2})");

            }
        }
    }
}
