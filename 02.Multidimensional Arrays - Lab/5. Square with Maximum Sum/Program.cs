using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[input[0], input[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = nums[j];
                }
            }
            int maxSum = matrix[0, 0];
            int maxRow = -1;
            int maxCol = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int squareSum = 0;
                    if (j + 1 >= matrix.GetLength(1) || i + 1 >= matrix.GetLength(0))
                    {
                        continue;
                    }
                    for (int currRow = 0; currRow < 2; currRow++)
                    {
                        for (int currCol = 0; currCol < 2; currCol++)
                        {
                            squareSum += matrix[i + currRow, j + currCol];
                        }
                    }
                    if (maxSum < squareSum)
                    {
                        maxSum = squareSum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            for (int i = maxRow; i < maxRow + 2; i++)
            {
                for (int j = maxCol; j < maxCol + 2; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
