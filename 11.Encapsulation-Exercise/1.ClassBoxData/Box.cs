using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _1.ClassBoxData
{
    public class Box
    {
		private double length;
        private double width;
        private double height;

		public Box(double length, double width, double height)
		{
			Length = length;
			Width = width;
			Height = height;
		}
        public double Length
		{
			get { return length; }
			private set
			{
				if(value <= 0)
				{
					throw new ArgumentException($"Length cannot be zero or negative.");
				}
				length = value;
			}
		}
		public double Width
		{
			get { return width; }
			private set
			{
				if(value <= 0)
				{
					throw new ArgumentException($"Width cannot be zero or negative.");
				}
				width = value;
			}
		}

		public double Height
		{
			get { return height; }
			private set
			{
				if(value <= 0)
				{
					throw new ArgumentException($"Height cannot be zero or negative.");
				}
				height = value;
			}
		}

		private double SurfaceArea()
		{
			return 2 * Length * Width + 2 * Height * Length + 2 * Height * Width;
		}

		private double LateralSurfaceArea()
		{
			return 2 * Height * Width + 2 * Height * Length;
		}

		private double Volume()
		{
			return Height * Width * Length;
		}

        public override string ToString()
        {
            return $"Surface Area - {SurfaceArea():F2}{Environment.NewLine}Lateral Surface Area - {LateralSurfaceArea():F2}{Environment.NewLine}Volume - {Volume():F2}";
        }
    }
}
