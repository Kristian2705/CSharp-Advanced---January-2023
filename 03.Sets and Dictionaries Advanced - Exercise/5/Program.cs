using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 5. Count Symbols
            Dictionary<char, int> symbolAppearances = new Dictionary<char, int>();
            string input = Console.ReadLine();
            foreach (var ch in input)
            {
                if (!symbolAppearances.ContainsKey(ch))
                {
                    symbolAppearances[ch] = 0;
                }
                symbolAppearances[ch]++;
            }
            foreach (var symbol in symbolAppearances.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
