using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.RawData
{
    public class Tire
    {
        private int age;
        private double pressure;
        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get { return age; } set { age = value; } }
        public double Pressure { get { return pressure; } set { pressure = value; } }
    }
}
