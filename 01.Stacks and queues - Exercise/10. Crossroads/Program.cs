using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int greenLightDur = int.Parse(Console.ReadLine());
            int freeWindowDur = int.Parse(Console.ReadLine());
            string input = string.Empty;
            int carsPassed = 0;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    continue;
                }
                if (cars.Count == 0)
                {
                    continue;
                }
                string current_car = cars.Peek();
                int current_greenLightDur = greenLightDur;
                while (current_car.Length <= current_greenLightDur)
                {
                    current_greenLightDur -= current_car.Length;
                    cars.Dequeue();
                    carsPassed++;
                    if (cars.Count == 0)
                    {
                        break;
                    }
                    current_car = cars.Peek();
                }
                if (cars.Count == 0)
                {
                    continue;
                }
                if (current_greenLightDur <= 0)
                {
                    continue;
                }
                current_car = cars.Peek();
                if (current_car.Length <= current_greenLightDur + freeWindowDur)
                {
                    cars.Dequeue();
                    carsPassed++;
                }
                else
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{current_car} was hit at {current_car[current_greenLightDur + freeWindowDur]}.");
                    return;
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
