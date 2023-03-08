int[] array = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int exceptionCounter = 0;

while(exceptionCounter < 3)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = input[0];
    try
    {
        switch (command)
        {
            case "Replace":
                int index = int.Parse(input[1]);
                int element = int.Parse(input[2]);
                array[index] = element;
                break;
            case "Print":
                int startIndex = int.Parse(input[1]);
                int endIndex = int.Parse(input[2]);
                List<int> arrayRange = new();
                for (int i = startIndex; i <= endIndex; i++)
                    arrayRange.Add(array[i]);
                Console.WriteLine(string.Join(", ", arrayRange));
                break;
            case "Show":
                int indexOfElementToShow = int.Parse(input[1]);
                Console.WriteLine(array[indexOfElementToShow]);
                break;
        }
    }
    catch (IndexOutOfRangeException)
    {
        exceptionCounter++;
        Console.WriteLine("The index does not exist!");
    }
    catch (FormatException)
    {
        exceptionCounter++;
        Console.WriteLine("The variable is not in the correct format!");
    }
}

Console.WriteLine(string.Join(", ", array));
