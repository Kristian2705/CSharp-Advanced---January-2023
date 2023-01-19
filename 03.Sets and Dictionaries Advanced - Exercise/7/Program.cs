using System;
using System.Collections.Generic;

namespace _7_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 7. The V-Logger
            Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> following = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] cmdTokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vlogger = cmdTokens[0];
                string command = cmdTokens[1];
                if (command == "joined")
                {
                    if (!followers.ContainsKey(vlogger))
                    {
                        followers[vlogger] = new List<string>();
                    }
                    if (!following.ContainsKey(vlogger))
                    {
                        following[vlogger] = new List<string>();
                    }
                }
                else
                {
                    string secondVlogger = cmdTokens[2];
                    if (!followers.ContainsKey(vlogger) || !followers.ContainsKey(secondVlogger))
                    {
                        continue;
                    }
                    if (vlogger == secondVlogger)
                    {
                        continue;
                    }
                    if (following[vlogger].Contains(secondVlogger))
                    {
                        continue;
                    }
                    following[vlogger].Add(secondVlogger);
                    followers[secondVlogger].Add(vlogger);
                }
            }
            Console.WriteLine($"The V-Logger has a total of {followers.Keys.Count} vloggers in its logs.");
            int counter = 0;
            foreach (var vlogger in followers.OrderByDescending(x => x.Value.Count).ThenBy(x => following[x.Key].Count))
            {
                counter++;
                List<string> vloggerFollowing = following[vlogger.Key];
                if (counter == 1)
                {
                    Console.WriteLine($"1. {vlogger.Key} : {vlogger.Value.Count} followers, {vloggerFollowing.Count} following");
                    if (vlogger.Value.Count > 0)
                    {
                        foreach (var follower in vlogger.Value.OrderBy(x => x))
                        {
                            Console.WriteLine($"*  {follower}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Count} followers, {vloggerFollowing.Count} following");
                }
            }
        }
    }
}
