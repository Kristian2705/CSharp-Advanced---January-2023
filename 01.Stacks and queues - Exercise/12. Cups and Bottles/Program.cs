using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int wastedWater = 0;
            int currCup = cups.Peek();
            int currBottle = bottles.Peek();
            while (true)
            {
                bool k = false;
                if (currCup <= currBottle)
                {
                    wastedWater += currBottle - currCup;
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    currCup -= currBottle;
                    k = true;
                    bottles.Pop();
                }
                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    break;
                }
                else if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    break;
                }
                if (!k)
                {
                    currCup = cups.Peek();
                }
                currBottle = bottles.Peek();
            }
        }
    }
}
