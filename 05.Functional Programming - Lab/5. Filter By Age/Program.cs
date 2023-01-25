using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> personAge = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (!personAge.ContainsKey(input[0]))
                {
                    personAge[input[0]] = int.Parse(input[1]);
                }
            }
            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<KeyValuePair<string, int>, int, bool> Filter(string condition)
            {
                if (condition == "younger")
                {
                    return (x, y) => x.Value < y;
                }
                else
                {
                    return (x, y) => x.Value >= y;
                }
            }
            Func<KeyValuePair<string, int>, int, bool> filter = Filter(condition);
            personAge = personAge
                .Where(x => filter(x, ageThreshold))
                .ToDictionary(x => x.Key, y => y.Value);
            Action<KeyValuePair<string, int>> Print(string format)
            {
                if (format == "name")
                {
                    return x => Console.WriteLine(x.Key);
                }
                else if (format == "age")
                {
                    return x => Console.WriteLine(x.Value);
                }
                return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
            Action<KeyValuePair<string, int>> printer = Print(format);
            foreach (var item in personAge)
            {
                printer(item);
            }
        }
    }
}
