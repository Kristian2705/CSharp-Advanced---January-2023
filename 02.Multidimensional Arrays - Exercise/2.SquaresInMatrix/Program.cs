using System;
using System.Linq;

namespace _2.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            char[,] matrix = new char[size[0], size[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int equalSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bool areEqual = true;
                    if (i + 1 >= matrix.GetLength(0) || j + 1 >= matrix.GetLength(1))
                    {
                        continue;
                    }
                    char curr_symbol = matrix[i, j];
                    for (int inRow = 0; inRow < 2; inRow++)
                    {
                        for (int inCol = 0; inCol < 2; inCol++)
                        {
                            if (matrix[i + inRow, j + inCol] != curr_symbol)
                            {
                                areEqual = false;
                                break;
                            }
                        }
                        if (!areEqual)
                        {
                            break;
                        }
                    }
                    if (!areEqual)
                    {
                        continue;
                    }
                    equalSum++;
                }
            }
            Console.WriteLine(equalSum);
        }
    }
}
