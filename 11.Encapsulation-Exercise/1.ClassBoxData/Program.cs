using _1.ClassBoxData;

try
{
    double length = double.Parse(Console.ReadLine());
    double width = double.Parse(Console.ReadLine());
    double height = double.Parse(Console.ReadLine());
    Console.WriteLine(new Box(length, width, height));
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}