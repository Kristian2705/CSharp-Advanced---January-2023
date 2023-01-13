using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int price = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> gunBarrel = new Queue<int>(bullets.Reverse());
            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> locksStack = new Stack<int>(locks.Reverse());
            int intelligenceValue = int.Parse(Console.ReadLine());
            int bulletCounter = 0;
            while (true)
            {
                if (gunBarrel.Peek() <= locksStack.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksStack.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                gunBarrel.Dequeue();
                bulletCounter++;
                if (bulletCounter % gunBarrelSize == 0 && gunBarrel.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                }
                if (locksStack.Count == 0)
                {
                    Console.WriteLine($"{gunBarrel.Count} bullets left. Earned ${intelligenceValue - bulletCounter * price}");
                    break;
                }
                if (gunBarrel.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksStack.Count}");
                    break;
                }
            }
        }
    }
}
