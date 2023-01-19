using System;
using System.Collections.Generic;
using System.Linq;

namespace _9_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 9. SoftUni Exam Results
            Dictionary<string, int> userPoints = new Dictionary<string, int>();
            Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] cmdTokens = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);
                string user = cmdTokens[0];
                string language = cmdTokens[1];
                if (language == "banned")
                {
                    if (userPoints.ContainsKey(user))
                    {
                        userPoints.Remove(user);
                    }
                    continue;
                }
                int points = int.Parse(cmdTokens[2]);
                if (!userPoints.ContainsKey(user))
                {
                    userPoints[user] = points;
                }
                else
                {
                    if (userPoints[user] < points)
                    {
                        userPoints[user] = points;
                    }
                }
                if (!languageSubmissions.ContainsKey(language))
                {
                    languageSubmissions[language] = 0;
                }
                languageSubmissions[language]++;
            }
            Console.WriteLine("Results:");
            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in languageSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
