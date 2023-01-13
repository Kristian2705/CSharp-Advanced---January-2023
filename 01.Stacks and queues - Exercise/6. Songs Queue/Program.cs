using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries));
            while (songs.Count != 0)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (input[0] == "Add")
                {
                    string newSong = string.Join(' ', input.Skip(1));
                    if (songs.Contains(newSong))
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                        continue;
                    }
                    songs.Enqueue(newSong);
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
