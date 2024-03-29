﻿using SimpleSnake.GameObjects.FoodUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';
        private const char EmptySpace = ' ';

        private readonly Wall wall;
        private readonly Queue<Point> snakeElements;
        private readonly List<Food> foods;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            foods = new List<Food>();
            foodIndex = RandomFoodNumber;

            InitializeFoods();
            SpawnFood();
            CreateSnake();
        }
        public int FoodEaten { get; private set; }
        private int RandomFoodNumber
            => new Random().Next(0, foods.Count);

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if(isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(newSnakeHead))
            {
                Eat(direction, currentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(EmptySpace);

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            for(int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            FoodEaten += length;

            SpawnFood();
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void InitializeFoods()
        {
            foods.Add(new FoodHash(wall));
            foods.Add(new FoodDollar(wall));
            foods.Add(new FoodAsterisk(wall));
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = direction.LeftX + snakeHead.LeftX;
            nextTopY = direction.TopY + snakeHead.TopY;
        }

        private void SpawnFood()
        {
            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakeElements);
        }
    }
}
