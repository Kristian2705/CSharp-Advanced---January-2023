using System;
using System.Collections.Generic;

namespace _4_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 4. Even Times
            Dictionary<int, int> numAppearances = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numAppearances.ContainsKey(num))
                {
                    numAppearances[num] = 0;
                }
                numAppearances[num]++;
            }
            foreach (var num in numAppearances)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
