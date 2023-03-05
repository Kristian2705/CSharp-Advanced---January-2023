using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;

        private double width;
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException();
                }
                height = value;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException();
                }
                width = value;
            }
        }

        public override double CalculatePerimeter()
            => 2 * (height + width);

        public override double CalculateArea()
            => height * width;

        public override string Draw()
            => $"Drawing {nameof(Rectangle)}";
    }
}
