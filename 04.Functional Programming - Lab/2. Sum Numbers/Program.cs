using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = x => int.Parse(x);
            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();
            Func<int[], int> count = x => x.Length;
            Func<int[], int> sum = x => x.Sum();
            Console.WriteLine(count(input));
            Console.WriteLine(sum(input));
        }
    }
}
