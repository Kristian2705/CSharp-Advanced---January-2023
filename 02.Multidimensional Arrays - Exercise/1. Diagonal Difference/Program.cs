using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int mainSum = 0;
            int secSum = 0;
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                    if (i == j)
                    {
                        mainSum += matrix[i, j];
                    }
                    if (i + j == n - 1)
                    {
                        secSum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(secSum - mainSum));
        }
    }
}
