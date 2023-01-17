using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int[,] matrix = new int[size[0], size[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int maxSum = matrix[0, 0];
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int sum = 0;
                    if (i + 2 >= matrix.GetLength(0) || j + 2 >= matrix.GetLength(1))
                    {
                        continue;
                    }
                    for (int inRow = 0; inRow < 3; inRow++)
                    {
                        for (int inCol = 0; inCol < 3; inCol++)
                        {
                            sum += matrix[inRow + i, inCol + j];
                        }
                    }
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[i + maxRow, j + maxCol]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
