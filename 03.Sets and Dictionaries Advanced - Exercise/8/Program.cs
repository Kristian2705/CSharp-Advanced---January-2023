using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 8. Ranking
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userResults = new Dictionary<string, Dictionary<string, int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] cmdTokens = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (!contests.ContainsKey(cmdTokens[0]))
                {
                    contests[cmdTokens[0]] = cmdTokens[1];
                }
            }
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdTokens = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = cmdTokens[0];
                string password = cmdTokens[1];
                string user = cmdTokens[2];
                int points = int.Parse(cmdTokens[3]);
                if (!contests.ContainsKey(contest))
                {
                    continue;
                }
                if (contests[contest] != password)
                {
                    continue;
                }
                if (!userResults.ContainsKey(user))
                {
                    userResults[user] = new Dictionary<string, int>();
                }
                if (!userResults[user].ContainsKey(contest))
                {
                    userResults[user][contest] = points;
                }
                else
                {
                    if (userResults[user][contest] < points)
                    {
                        userResults[user][contest] = points;
                    }
                }
            }
            int mostPoints = -1;
            int sumPoints = 0;
            string bestUser = string.Empty;
            foreach (var user in userResults)
            {
                foreach (var points in user.Value)
                {
                    sumPoints += points.Value;
                }
                if (mostPoints < sumPoints)
                {
                    mostPoints = sumPoints;
                    bestUser = user.Key;
                    sumPoints = 0;
                }
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {mostPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in userResults.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var points in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {points.Key} -> {points.Value}");
                }
            }
        }
    }
}
