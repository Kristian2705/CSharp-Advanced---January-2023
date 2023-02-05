using _5.GenericCountMethodString;

int n = int.Parse(Console.ReadLine());

List<Box<string>> boxes = new();

for(int i = 0; i < n; i++)
{
    string s = Console.ReadLine();
    Box<string> box = new(s);
    boxes.Add(box);
}

string item = Console.ReadLine();

int counter = 0;
foreach(Box<string> box in boxes)
{
    counter += box.CompareCounter(item);
}

Console.WriteLine(counter);


