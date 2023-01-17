using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = input[j];
                }
            }
            int maxAttacks = -1;
            int removeCounter = 0;
            while (maxAttacks != 0)
            {
                maxAttacks = -1;
                int maxI = -1;
                int maxJ = -1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (board[i, j] == 'K')
                        {
                            int currAttacks = FindKnightAttacks(i, j, board);
                            if (maxAttacks < currAttacks)
                            {
                                maxAttacks = currAttacks;
                                maxI = i;
                                maxJ = j;
                            }
                        }
                    }
                }
                if (maxAttacks > 0)
                {
                    board[maxI, maxJ] = '0';
                    removeCounter++;
                }
            }
            Console.WriteLine(removeCounter);
        }

        static int FindKnightAttacks(int i, int j, char[,] board)
        {
            int[] X = { 2, 1, -1, -2,
                   -2, -1, 1, 2 };
            int[] Y = { 1, 2, 2, 1,
                   -1, -2, -2, -1 };
            int attackCounter = 0;
            for (int k = 0; k < 8; k++)
            {
                int x = i + X[k];
                int y = j + Y[k];
                if (x >= 0 && y >= 0 &&
                    x < board.GetLength(0) && y < board.GetLength(1) &&
                    board[x, y] == 'K')
                    attackCounter++;
            }
            return attackCounter;
        }
    }
}
