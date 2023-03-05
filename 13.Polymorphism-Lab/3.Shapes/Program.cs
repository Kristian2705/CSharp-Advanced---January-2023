namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Shape circle = new Circle(3);
            Console.WriteLine(circle.Draw());
        }
    }
}
