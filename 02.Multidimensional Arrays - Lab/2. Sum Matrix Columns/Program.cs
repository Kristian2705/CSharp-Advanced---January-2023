using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine()
                .Split(", ");
            int[,] matrix = new int[int.Parse(size[0]), int.Parse(size[1])];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] cols = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = cols[j];
                }
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, j];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
