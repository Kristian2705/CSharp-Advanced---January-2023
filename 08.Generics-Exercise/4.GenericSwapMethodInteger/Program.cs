using _4.GenericSwapMethodInteger;

int n = int.Parse(Console.ReadLine());

List<Box<int>> boxes = new();

for (int i = 0; i < n; i++)
{
    int num = int.Parse(Console.ReadLine());
    Box<int> box = new(num);
    boxes.Add(box);
}

int[] indices = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Swap(indices[0], indices[1], boxes);

foreach (Box<int> box in boxes)
{
    Console.WriteLine(box.ToString());
}

static void Swap(int index1, int index2, List<Box<int>> boxes)
{
    var temp = boxes[index1];
    boxes[index1] = boxes[index2];
    boxes[index2] = temp;
}