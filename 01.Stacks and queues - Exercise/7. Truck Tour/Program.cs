using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int petrol = 0;
            int distance = 0;
            Queue<int[]> route = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();
                route.Enqueue(pump);
            }
            int counter = 0;
            int ind = 0;
            while (true)
            {
                while (true)
                {
                    petrol += route.Peek()[0];
                    distance = route.Peek()[1];
                    petrol -= distance;
                    route.Enqueue(route.Dequeue());
                    ind++;
                    if (ind == n)
                    {
                        ind = 0;
                    }
                    counter++;
                    if (counter == n)
                    {
                        Console.WriteLine(ind);
                        return;
                    }
                    if (petrol < 0)
                    {
                        break;
                    }
                }
                petrol = 0;
                distance = 0;
                counter = 0;
            }
        }
    }
}
