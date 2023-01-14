using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long rows = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[rows][];
            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                pascalTriangle[i] = new long[i + 1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][pascalTriangle[i].Length - 1] = 1;
                if (i >= 2)
                {
                    for (int j = 1; j < pascalTriangle[i].Length - 1; j++)
                    {
                        pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                    }
                }
            }
            foreach (long[] row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
