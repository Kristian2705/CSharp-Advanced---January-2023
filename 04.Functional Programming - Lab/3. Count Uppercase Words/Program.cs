using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> upperCaseWords = x => char.IsUpper(x[0]);
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => upperCaseWords(x))
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
