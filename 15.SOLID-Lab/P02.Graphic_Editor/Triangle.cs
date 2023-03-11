using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Graphic_Editor
{
    public class Triangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Triangle");
        }
    }
}
