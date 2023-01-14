using System;
using System.Linq;

namespace _6._JaggedArray_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdTokens = input
                    .Split();
                if (cmdTokens[0] == "Add")
                {
                    int row = int.Parse(cmdTokens[1]);
                    int col = int.Parse(cmdTokens[2]);
                    if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                    int value = int.Parse(cmdTokens[3]);
                    jaggedArray[row][col] += value;
                }
                else
                {
                    int row = int.Parse(cmdTokens[1]);
                    int col = int.Parse(cmdTokens[2]);
                    if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }
                    int value = int.Parse(cmdTokens[3]);
                    jaggedArray[row][col] -= value;
                }
            }
            foreach (int[] array in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}
