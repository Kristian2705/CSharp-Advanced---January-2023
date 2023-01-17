using System;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[n, n];
            int startRow = -1;
            int startCol = -1;
            int totalCoals = 0;
            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = row[j];
                    if (field[i, j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                    }
                    else if (field[i, j] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }
            int currRow = startRow;
            int currCol = startCol;
            int coalCounter = 0;
            bool reachedEnd = false;
            bool collectedCoals = false;
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "left":
                        if (currCol - 1 < 0)
                        {
                            continue;
                        }
                        currCol -= 1;
                        CheckField(field, totalCoals, currRow, currCol, ref coalCounter, ref reachedEnd, ref collectedCoals);
                        break;
                    case "right":
                        if (currCol + 1 >= field.GetLength(1))
                        {
                            continue;
                        }
                        currCol += 1;
                        CheckField(field, totalCoals, currRow, currCol, ref coalCounter, ref reachedEnd, ref collectedCoals);
                        break;
                    case "up":
                        if (currRow - 1 < 0)
                        {
                            continue;
                        }
                        currRow -= 1;
                        CheckField(field, totalCoals, currRow, currCol, ref coalCounter, ref reachedEnd, ref collectedCoals);
                        break;
                    case "down":
                        if (currRow + 1 >= field.GetLength(0))
                        {
                            continue;
                        }
                        currRow += 1;
                        CheckField(field, totalCoals, currRow, currCol, ref coalCounter, ref reachedEnd, ref collectedCoals);
                        break;
                }
                if (reachedEnd)
                {
                    Console.WriteLine($"Game over! ({currRow}, {currCol})");
                    return;
                }
                if (collectedCoals)
                {
                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                    return;
                }
            }
            Console.WriteLine($"{totalCoals - coalCounter} coals left. ({currRow}, {currCol})");
        }

        private static void CheckField(char[,] field, int totalCoals, int currRow, int currCol, ref int coalCounter, ref bool reachedEnd, ref bool collectedCoals)
        {
            if (field[currRow, currCol] == 'c')
            {
                coalCounter++;
                field[currRow, currCol] = '*';
                if (coalCounter == totalCoals)
                {
                    collectedCoals = true;
                }
            }
            else if (field[currRow, currCol] == 'e')
            {
                reachedEnd = true;
            }
        }
    }
}
