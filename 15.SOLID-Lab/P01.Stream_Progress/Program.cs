using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            StreamProgressInfo stream = new(new File("Fyre", 12, 24));
            Console.WriteLine(stream.CalculateCurrentPercent()); 
        }
    }
}
