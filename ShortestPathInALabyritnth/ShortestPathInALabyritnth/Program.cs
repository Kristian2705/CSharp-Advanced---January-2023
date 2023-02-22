using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
char[,] board = new char[n, m];
int rowStart = -1;
int colStart = -1;
for (int i = 0; i < n; i++)
{
    string row = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        board[i, j] = row[j];
        if (board[i, j].ToString().ToLower() == "c")
        {
            rowStart = i;
            colStart = j;
        }
    }
}
List<string> allPaths = new();
GetPaths(board, rowStart, colStart, new bool[n, m], "", allPaths);
int min = int.MaxValue;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Shortest path(s):");
for (int i = 0; i < allPaths.Count; i++)
{
    if (min > allPaths[i].Length)
    {
        min = allPaths[i].Length;
    }
}
foreach (var path in allPaths.Where(x => x.Length == min))
{
    Console.WriteLine(path);
}

static void GetPaths(char[,] board, int row, int col, bool[,] visitedPlaces, string path, List<string> paths)
{
    if (board[row, col].ToString().ToLower() == "f")
    {
        Console.WriteLine(path);
        paths.Add(path);
        return;
    }
    visitedPlaces[row, col] = true;
    char lastMove = ' ';
    if (board[row, col].ToString().ToLower() == "t")
    {
        lastMove = path[path.Length - 1];
        switch (lastMove)
        {
            case 'U':
                if (IsSafe(board, row - 1, col, visitedPlaces))
                {
                    if (board[row - 1, col].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    while (board[row, col].ToString().ToLower() == "t")
                    {
                        row--;
                        visitedPlaces[row, col] = true;
                    }
                    if (board[row, col].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    if (board[row, col] == '_')
                    {
                        GetPaths(board, row, col, visitedPlaces, path, paths);
                        row++;
                        while (board[row, col].ToString().ToLower() == "t")
                        {
                            visitedPlaces[row, col] = false;
                            row++;
                        }
                    }
                }
                visitedPlaces[row, col] = false;
                break;
            case 'D':
                if (IsSafe(board, row + 1, col, visitedPlaces))
                {
                    if (board[row + 1, col].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    while (board[row, col].ToString().ToLower() == "t")
                    {
                        row++;
                        visitedPlaces[row, col] = true;
                    }
                    if (board[row, col].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    if (board[row, col] == '_')
                    {
                        GetPaths(board, row, col, visitedPlaces, path, paths);
                        row--;
                        while (board[row, col].ToString().ToLower() == "t")
                        {
                            visitedPlaces[row, col] = false;
                            row--;
                        }
                    }
                }
                visitedPlaces[row, col] = false;
                break;
            case 'L':
                if (IsSafe(board, row, col - 1, visitedPlaces))
                {
                    if (board[row, col - 1].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    while (board[row, col].ToString().ToLower() == "t")
                    {
                        col--;
                        visitedPlaces[row, col] = true;
                    }
                    if (board[row, col].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    if (board[row, col] == '_' || IsSafe(board, row, col, visitedPlaces))
                    {
                        GetPaths(board, row, col, visitedPlaces, path, paths);
                        col++;
                        while (board[row, col].ToString().ToLower() == "t")
                        {
                            visitedPlaces[row, col] = false;
                            col++;
                        }
                    }
                }
                visitedPlaces[row, col] = false;
                break;
            case 'R':
                if (IsSafe(board, row, col + 1, visitedPlaces))
                {
                    if (board[row, col + 1].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    while (board[row, col].ToString().ToLower() == "t")
                    {
                        col++;
                        visitedPlaces[row, col] = true;
                    }
                    if (board[row, col].ToString().ToLower() == "f")
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                        visitedPlaces[row, col] = false;
                        return;
                    }
                    if (board[row, col] == '_')
                    {
                        GetPaths(board, row, col, visitedPlaces, path, paths);
                        col--;
                        while (board[row, col].ToString().ToLower() == "t")
                        {
                            visitedPlaces[row, col] = false;
                            col--;
                        }
                    }
                }
                visitedPlaces[row, col] = false;
                break;
        }
    }
    else
    {
        if (IsSafe(board, row - 1, col, visitedPlaces))
        {
            if (board[row - 1, col].ToString().ToLower() == "t")
            {
                row--;
                if (IsSafe(board, row - 1, col, visitedPlaces))
                {
                    visitedPlaces[row, col] = true;
                    GetPaths(board, row - 1, col, visitedPlaces, path + "U", paths);
                    visitedPlaces[row, col] = false;
                    row++;
                }
                else
                {
                    row++;
                }
            }
            else
            {
                GetPaths(board, row - 1, col, visitedPlaces, path + "U", paths);
            }
        }
        if (IsSafe(board, row + 1, col, visitedPlaces))
        {
            if (board[row + 1, col].ToString().ToLower() == "t")
            {
                row++;
                if (IsSafe(board, row + 1, col, visitedPlaces))
                {
                    visitedPlaces[row, col] = true;
                    GetPaths(board, row + 1, col, visitedPlaces, path + "D", paths);
                    visitedPlaces[row, col] = false;
                    row--;
                }
                else
                {
                    row--;
                }
            }
            else
            {
                GetPaths(board, row + 1, col, visitedPlaces, path + "D", paths);
            }
        }
        if (IsSafe(board, row, col - 1, visitedPlaces))
        {
            if (board[row, col - 1].ToString().ToLower() == "t")
            {
                col--;
                if (IsSafe(board, row, col - 1, visitedPlaces))
                {
                    visitedPlaces[row, col] = true;
                    GetPaths(board, row, col - 1, visitedPlaces, path + "L", paths);
                    visitedPlaces[row, col] = false;
                    col++;
                }
                else
                {
                    col++;
                }
            }
            else
            {
                GetPaths(board, row, col - 1, visitedPlaces, path + "L", paths);
            }
        }
        if (IsSafe(board, row, col + 1, visitedPlaces))
        {
            if (board[row, col + 1].ToString().ToLower() == "t")
            {
                col++;
                if (IsSafe(board, row, col + 1, visitedPlaces))
                {
                    visitedPlaces[row, col] = true;
                    GetPaths(board, row, col + 1, visitedPlaces, path + "R", paths);
                    visitedPlaces[row, col] = false;
                    col--;
                }
                else
                {
                    col--;
                }
            }
            else
            {
                GetPaths(board, row, col + 1, visitedPlaces, path + "R", paths);
            }
        }
        visitedPlaces[row, col] = false;
    }
}


static bool IsSafe(char[,] board, int row, int col, bool[,] bools)
    => row >= 0 && col >= 0 && row < board.GetLength(0) && col < board.GetLength(1) && !bools[row, col] && board[row, col].ToString().ToLower() != "b";

/*
5
5
_C_b_
_B___
__bTB
btB__
__f__

5
5
c_b__
___b_
_t__F
_ttt_
_____

6
6
_bC_B_
__BTT_
B_t_b_
___b__
Tbt_tb
_t_F__

7
2
F_
T_
T_
__
T_
T_
CB

3
7
_bbbb__
FtttttC
_bbbb__

3
6
______
fTtT_C
______

5
5
C_bb_
_t_bb
_t___
b_ttF
b____

5
6
B___BC
__T__B
_TFT_B
__T___
B___B_
*/
