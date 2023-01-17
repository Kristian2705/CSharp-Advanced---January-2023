using System;
using System.Linq;

namespace _6.JaggedArrManip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jaggedArr = new long[n][];
            for (int i = 0; i < n; i++)
            {
                jaggedArr[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (jaggedArr[i].Length == jaggedArr[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] *= 2;
                        jaggedArr[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArr[i].Length; j++)
                    {
                        jaggedArr[i][j] /= 2;
                    }
                    for (int j = 0; j < jaggedArr[i + 1].Length; j++)
                    {
                        jaggedArr[i + 1][j] /= 2;
                    }
                }
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdTokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdTokens[0];
                int row = int.Parse(cmdTokens[1]);
                int col = int.Parse(cmdTokens[2]);
                int value = int.Parse(cmdTokens[3]);
                if (row < 0 || row >= jaggedArr.Length || col < 0 || col >= jaggedArr[row].Length)
                {
                    continue;
                }
                if (command == "Add")
                {
                    jaggedArr[row][col] += value;
                }
                else
                {
                    jaggedArr[row][col] -= value;
                }
            }
            PrintJaggedArr(jaggedArr);
        }

        static void PrintJaggedArr(long[][] jaggedArr)
        {
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[i]));
            }
        }
    }
}
