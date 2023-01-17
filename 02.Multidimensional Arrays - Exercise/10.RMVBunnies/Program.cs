using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RMVBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int n = size[0];
            int m = size[1];
            char[,] lair = new char[n, m];
            int startRow = -1;
            int startCol = -1;
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    lair[i, j] = row[j];
                    if (lair[i, j] == 'P')
                    {
                        startRow = i;
                        startCol = j;
                    }
                }
            }
            string commands = Console.ReadLine();
            int currRow = startRow;
            int currCol = startCol;
            bool hasDied = false;
            bool hasWon = false;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        if (currCol - 1 < 0)
                        {
                            hasWon = true;
                            lair[currRow, currCol] = '.';
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                        }
                        else if (lair[currRow, currCol - 1] == '.')
                        {
                            lair[currRow, currCol] = '.';
                            lair[currRow, currCol - 1] = 'P';
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currCol--;
                        }
                        else if (lair[currRow, currCol - 1] == 'B')
                        {
                            lair[currRow, currCol] = '.';
                            hasDied = true;
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currCol--;
                        }
                        break;
                    case 'R':
                        if (currCol + 1 == m)
                        {
                            hasWon = true;
                            lair[currRow, currCol] = '.';
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                        }
                        else if (lair[currRow, currCol + 1] == '.')
                        {
                            lair[currRow, currCol] = '.';
                            lair[currRow, currCol + 1] = 'P';
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currCol++;
                        }
                        else if (lair[currRow, currCol + 1] == 'B')
                        {
                            lair[currRow, currCol] = '.';
                            hasDied = true;
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currCol++;
                        }
                        break;
                    case 'U':
                        if (currRow - 1 < 0)
                        {
                            lair[currRow, currCol] = '.';
                            hasWon = true;
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                        }
                        else if (lair[currRow - 1, currCol] == '.')
                        {
                            lair[currRow, currCol] = '.';
                            lair[currRow - 1, currCol] = 'P';
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currRow--;
                        }
                        else if (lair[currRow - 1, currCol] == 'B')
                        {
                            lair[currRow, currCol] = '.';
                            hasDied = true;
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currRow--;
                        }
                        break;
                    case 'D':
                        if (currRow + 1 == n)
                        {
                            lair[currRow, currCol] = '.';
                            hasWon = true;
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                        }
                        else if (lair[currRow + 1, currCol] == '.')
                        {
                            lair[currRow, currCol] = '.';
                            lair[currRow + 1, currCol] = 'P';
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currRow++;
                        }
                        else if (lair[currRow + 1, currCol] == 'B')
                        {
                            lair[currRow, currCol] = '.';
                            hasDied = true;
                            SpreadBunnies(n, m, lair, currRow, currCol, ref hasDied);
                            currRow++;
                        }
                        break;
                }
                if (hasWon)
                {
                    PrintLair(lair);
                    Console.WriteLine($"won: {currRow} {currCol}");
                    return;
                }
                if (hasDied)
                {
                    PrintLair(lair);
                    Console.WriteLine($"dead: {currRow} {currCol}");
                    return;
                }
            }
            PrintLair(lair);
        }

        private static void SpreadBunnies(int n, int m, char[,] lair, int currRow, int currCol, ref bool hasDied)
        {
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (lair[i, j] == 'B')
                    {
                        X.Add(i);
                        Y.Add(j);
                    }
                }
            }
            for (int i = 0; i < X.Count; i++)
            {
                hasDied = CheckIfDead(n, m, lair, hasDied, X[i], Y[i]);
            }
        }

        private static bool CheckIfDead(int n, int m, char[,] lair, bool hasDied, int i, int j)
        {
            if (i - 1 >= 0)
            {
                if (lair[i - 1, j] == 'P')
                {
                    hasDied = true;
                }
                lair[i - 1, j] = 'B';
            }
            if (i + 1 < n)
            {
                if (lair[i + 1, j] == 'P')
                {
                    hasDied = true;
                }
                lair[i + 1, j] = 'B';
            }
            if (j - 1 >= 0)
            {
                if (lair[i, j - 1] == 'P')
                {
                    hasDied = true;
                }
                lair[i, j - 1] = 'B';
            }
            if (j + 1 < m)
            {
                if (lair[i, j + 1] == 'P')
                {
                    hasDied = true;
                }
                lair[i, j + 1] = 'B';
            }
            return hasDied;
        }

        private static void PrintLair(char[,] lair)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
