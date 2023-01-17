using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            string snake = Console.ReadLine();
            char[,] matrix = new char[size[0], size[1]];
            Queue<char> snakeQueue = new Queue<char>(snake.ToCharArray());
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snakeQueue.Dequeue();
                        snakeQueue.Enqueue(matrix[i, j]);
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snakeQueue.Dequeue();
                        snakeQueue.Enqueue(matrix[i, j]);
                    }
                }
            }
            PrintMatrix(matrix);
        }

        static Queue<char> ReverseQueue(Queue<char> queue)
        {
            Stack<char> stack = new Stack<char>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
