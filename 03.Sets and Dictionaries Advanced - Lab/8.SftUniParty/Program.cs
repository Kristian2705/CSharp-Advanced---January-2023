using System;
using System.Collections.Generic;

namespace _8.SftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIPs = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            string input = string.Empty;
            bool isPartyTime = false;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "PARTY" && !isPartyTime)
                {
                    if (char.IsDigit(input[0]))
                    {
                        VIPs.Add(input);
                    }
                    else
                    {
                        regularGuests.Add(input);
                    }
                    continue;
                }
                else
                {
                    isPartyTime = true;
                }
                if (isPartyTime)
                {
                    if (char.IsDigit(input[0]))
                    {
                        if (VIPs.Contains(input))
                        {
                            VIPs.Remove(input);
                        }
                    }
                    else
                    {
                        if (regularGuests.Contains(input))
                        {
                            regularGuests.Remove(input);
                        }
                    }
                }
            }
            Console.WriteLine(VIPs.Count + regularGuests.Count);
            foreach (var guest in VIPs)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
