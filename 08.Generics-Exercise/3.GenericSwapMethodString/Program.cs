using _3.GenericSwapMethodString;

int n = int.Parse(Console.ReadLine());

List<Box<string>> boxes = new();

for(int i = 0; i < n; i++)
{
    string s = Console.ReadLine();
    Box<string> box = new(s);
    boxes.Add(box);
}

int[] indices = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Swap(indices[0], indices[1], boxes);

foreach(Box<string> box in boxes)
{
    Console.WriteLine(box.ToString());
}

static void Swap(int index1, int index2, List<Box<string>> boxes)
{
    var temp = boxes[index1]; 
    boxes[index1] = boxes[index2]; 
    boxes[index2] = temp;
}