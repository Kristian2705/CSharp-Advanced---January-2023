using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.FoodUnits
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;
        private ConsoleColor color;
        protected Food(Wall wall, char foodSymbol, int points, ConsoleColor color)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            random = new Random();
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            this.color = color;
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            SetLeftX(random.Next(2, wall.LeftX - 2));
            SetTopY(random.Next(2, wall.TopY - 2));

            bool isSnakeElement = snakeElements
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isSnakeElement)
            {
                SetLeftX(random.Next(2, wall.LeftX - 2));
                SetTopY(random.Next(2, wall.TopY - 2));

                isSnakeElement = snakeElements
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = color;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
            => snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;
    }
}
