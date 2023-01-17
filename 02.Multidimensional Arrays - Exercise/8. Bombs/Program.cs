using System;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                int[] indices = input[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                int indI = indices[0];
                int indJ = indices[1];
                matrix = Explode(indI, indJ, matrix);
            }
            int aliveCells = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        aliveCells++;
                        sum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(matrix);
        }

        static int[,] Explode(int i, int j, int[,] matrix)
        {
            int value = matrix[i, j];
            if (value <= 0)
            {
                return matrix;
            }
            int[] X = { 1, 1, 1, 0,
                   -1, -1, -1, 0 };
            int[] Y = { -1, 0, 1, 1,
                   1, 0, -1, -1 };
            for (int k = 0; k < 8; k++)
            {
                int x = i + X[k];
                int y = j + Y[k];
                if (x >= 0 && y >= 0 && x < matrix.GetLength(0) && y < matrix.GetLength(1) && matrix[x, y] > 0)
                {
                    matrix[x, y] -= value;
                }
            }
            matrix[i, j] = 0;
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
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
