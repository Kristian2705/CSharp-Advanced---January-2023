int n = int.Parse(Console.ReadLine());
int[,] board = new int[n, n];

Console.WriteLine(FindQueens(board, 0));

int FindQueens(int[,] board, int row)
{
    if (row == board.GetLength(0))
    {
        PrintBoard(board);
        return 1;
    }
    int foundQueens = 0;
    for (int col = 0; col < board.GetLength(1); col++)
    {
        if (IsSafe(board, row, col))
        {
            board[row, col] = 1;
            foundQueens += FindQueens(board, row + 1);
            board[row, col] = 0;
        }
    }
    return foundQueens;
}

bool IsSafe(int[,] board, int row, int col)
{
    for (int i = 0; i < board.GetLength(0); i++)
    {
        if (row - i >= 0 && board[row - i, col] == 1)
        {
            return false;
        }
        if (row + i < board.GetLength(0) && board[row + i, col] == 1)
        {
            return false;
        }
        if (col - i >= 0 && board[row, col - i] == 1)
        {
            return false;
        }
        if (col + i < board.GetLength(1) && board[row, col + i] == 1)
        {
            return false;
        }
        if (row - i >= 0 && col - i >= 0 && board[row - i, col - i] == 1)
        {
            return false;
        }
        if (row - i >= 0 && col + i < board.GetLength(1) && board[row - i, col + i] == 1)
        {
            return false;
        }
        if (row + i < board.GetLength(0) && col - i >= 0 && board[row + i, col - i] == 1)
        {
            return false;
        }
        if (row + i < board.GetLength(0) && col + i < board.GetLength(1) && board[row + i, col + i] == 1)
        {
            return false;
        }
    }
    return true;
}

void PrintBoard(int[,] board)
{
    for (int i = 0; i < board.GetLength(0); i++)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[i, j] != 0)
            {
                Console.Write("Q");
            }
            else
            {
                Console.Write("-");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine();
}
