using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            string[,] matrix = new string[size[0], size[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdTokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdTokens[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (cmdTokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                int row1 = int.Parse(cmdTokens[1]);
                int col1 = int.Parse(cmdTokens[2]);
                int row2 = int.Parse(cmdTokens[3]);
                int col2 = int.Parse(cmdTokens[4]);
                if (row1 < 0 || row1 >= matrix.GetLength(0) || col1 < 0 || col1 >= matrix.GetLength(1) || row2 < 0 || row2 >= matrix.GetLength(0) || col2 < 0 || col2 >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string swap = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = swap;
                PrintMatrix(matrix);
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
