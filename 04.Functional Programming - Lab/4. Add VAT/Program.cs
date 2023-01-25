using System;
using System.Linq;

namespace _4._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            Action<double> func = x => Console.WriteLine($"{x + x * 0.2:F2}");
            for (int i = 0; i < nums.Length; i++)
            {
                func(nums[i]);
            }
        }
    }
}
