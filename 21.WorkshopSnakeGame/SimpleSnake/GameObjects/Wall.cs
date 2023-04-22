using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WallSymbol = '\u25A0';
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeBorder();
        }

        public bool IsPointOfWall(Point snakeHead)
            => snakeHead.TopY == 0 || snakeHead.LeftX == 0 ||
            snakeHead.LeftX == LeftX - 1 || snakeHead.TopY == TopY;

        private void DrawHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        private void DrawVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, WallSymbol);
            }
        }

        private void InitializeBorder()
        {
            DrawHorizontalLine(0);
            DrawHorizontalLine(TopY);

            DrawVerticalLine(0);
            DrawVerticalLine(LeftX - 1);
        }
    }
}
