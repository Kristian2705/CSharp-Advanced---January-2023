using _6.GenericCountMethodDouble;

int n = int.Parse(Console.ReadLine());

List<Box<double>> boxes = new();

for (int i = 0; i < n; i++)
{
    double num = double.Parse(Console.ReadLine());
    Box<double> box = new(num);
    boxes.Add(box);
}

double item = double.Parse(Console.ReadLine());

int counter = 0;
foreach (Box<double> box in boxes)
{
    counter += box.CompareCounter(item);
}

Console.WriteLine(counter);