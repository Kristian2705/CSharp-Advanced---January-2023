using System;
using System.Collections.Generic;

namespace _7.Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdTokens = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = cmdTokens[0];
                string carNum = cmdTokens[1];
                if (direction == "IN")
                {
                    cars.Add(carNum);
                }
                else
                {
                    if (cars.Contains(carNum))
                    {
                        cars.Remove(carNum);
                    }
                }
            }
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
