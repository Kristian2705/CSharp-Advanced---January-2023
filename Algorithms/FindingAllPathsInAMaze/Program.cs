string[] maze = new string[]
{
    "010001",
    "01010E",
    "010100",
    "000000"
};
const int startRow = 0;
const int startCol = 0;
PrintMaze(maze);
Console.WriteLine();
Console.WriteLine("All possible path starting from [0][0]:");
FindPaths(startRow, startCol, maze, new bool[maze.GetLength(0), maze[0].Length], "");

void FindPaths(int row, int col, string[] maze, bool[,] visitedPlaces, string path)
{
    if (maze[row][col] == 'E')
    {
        Console.WriteLine(path);
        return;
    }
    visitedPlaces[row, col] = true;
    if(IsSafe(row - 1, col, maze, visitedPlaces))
    {
        FindPaths(row - 1, col, maze, visitedPlaces, path + "U");
    }
    if (IsSafe(row + 1, col, maze, visitedPlaces))
    {
        FindPaths(row + 1, col, maze, visitedPlaces, path + "D");
    }
    if (IsSafe(row, col - 1, maze, visitedPlaces))
    {
        FindPaths(row, col - 1, maze, visitedPlaces, path + "L");
    }
    if (IsSafe(row, col + 1, maze, visitedPlaces))
    {
        FindPaths(row, col + 1, maze, visitedPlaces, path + "R");
    }
    visitedPlaces[row, col] = false;
}

bool IsSafe(int row, int col, string[] maze, bool[,] visitedPlaces)
    => row >= 0 && col >= 0 && row < maze.GetLength(0) && col < maze[0].Length && !visitedPlaces[row, col] && maze[row][col] != '1';

void PrintMaze(string[] maze)
{
    for(int i = 0; i < maze.Length; i++)
    {
        Console.WriteLine(maze[i]);
    }
}