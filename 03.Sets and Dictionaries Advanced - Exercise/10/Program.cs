using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Title: 10. ForceBook
            Dictionary<string, HashSet<string>> sideMembers = new Dictionary<string, HashSet<string>>();
            string input = string.Empty;
            string[] separators = { " | ", " -> " };
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                int operation = 0;
                if (input.Contains(" | "))
                {
                    operation = 1;
                }
                string[] cmdTokens = input
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (operation == 1)
                {
                    string forceSide = cmdTokens[0];
                    string user = cmdTokens[1];
                    if (!sideMembers.ContainsKey(forceSide))
                    {
                        sideMembers[forceSide] = new HashSet<string>();
                    }
                    if (sideMembers.Any(x => x.Value.Contains(user)))
                    {
                        continue;
                    }
                    sideMembers[forceSide].Add(user);
                }
                else
                {
                    string forceSide = cmdTokens[1];
                    string user = cmdTokens[0];
                    if (sideMembers.Any(x => x.Value.Contains(user)))
                    {
                        string currKey = string.Empty;
                        foreach (var kvp in sideMembers)
                        {
                            foreach (var currUser in kvp.Value)
                            {
                                if (currUser == user)
                                {
                                    currKey = kvp.Key;
                                }
                            }
                        }
                        sideMembers[currKey].Remove(user);
                        if (!sideMembers.ContainsKey(forceSide))
                        {
                            sideMembers[forceSide] = new HashSet<string>();
                        }
                        sideMembers[forceSide].Add(user);
                        Console.WriteLine($"{user} joins the {forceSide} side!");
                    }
                    else
                    {
                        if (!sideMembers.ContainsKey(forceSide))
                        {
                            sideMembers[forceSide] = new HashSet<string>();
                        }
                        sideMembers[forceSide].Add(user);
                        Console.WriteLine($"{user} joins the {forceSide} side!");
                    }
                }
            }
            foreach (var kvp in sideMembers.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                    foreach (var user in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
