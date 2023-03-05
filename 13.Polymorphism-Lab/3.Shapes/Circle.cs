using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                radius = value;
            }
        }

        public override double CalculatePerimeter()
            => 2 * Math.PI * radius;

        public override double CalculateArea()
            => Math.PI * radius * radius;

        public override string Draw()
            => $"Drawing {nameof(Circle)}";
    }
}
