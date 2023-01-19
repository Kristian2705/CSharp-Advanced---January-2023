using System;
using System.Collections.Generic;

namespace _6_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 6. Wardrobe
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = input[0];
                string[] clothes = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe[colour] = new Dictionary<string, int>();
                }
                foreach (var cloth in clothes)
                {
                    if (!wardrobe[colour].ContainsKey(cloth))
                    {
                        wardrobe[colour][cloth] = 0;
                    }
                    wardrobe[colour][cloth]++;
                }
            }
            string[] desiredOutfit = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var colour in wardrobe)
            {
                int foundCounter = 0;
                if (desiredOutfit[0] == colour.Key)
                {
                    foundCounter++;
                }
                Console.WriteLine($"{colour.Key} clothes:");
                foreach (var outfit in colour.Value)
                {
                    if (desiredOutfit[1] == outfit.Key)
                    {
                        foundCounter++;
                    }
                    if (foundCounter != 2)
                    {
                        Console.WriteLine($"* {outfit.Key} - {outfit.Value}");
                        continue;
                    }
                    Console.WriteLine($"* {outfit.Key} - {outfit.Value} (found!)");
                    foundCounter = 1;
                }
            }
        }
    }
}
