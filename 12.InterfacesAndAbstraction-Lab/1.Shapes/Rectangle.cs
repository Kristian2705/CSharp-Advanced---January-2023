using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            for(int i = 1; i <= this.height; i++)
            {
                if(i == 1 || i == this.height)
                {
                    for(int j = 1; j <= this.width; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    for(int j = 1; j <= this.width; j++)
                    {
                        if(j == 1 || j == this.width)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
