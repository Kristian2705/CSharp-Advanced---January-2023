using _4.BorderControl;

string input = string.Empty;

List<IIdentifiable> identifiableGroup = new();

while((input = Console.ReadLine()) != "End")
{
    string[] info = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if(info.Length == 2)
    {
        IIdentifiable robot = new Robot(info[0], info[1]);
        identifiableGroup.Add(robot);
    }
    else if(info.Length == 3)
    {
        IIdentifiable person = new Person(info[0], int.Parse(info[1]), info[2]);
        identifiableGroup.Add(person);
    }
}

string fakeIdLastDigits = Console.ReadLine();

foreach(var identifiable in identifiableGroup)
{
    if (identifiable.Id.EndsWith(fakeIdLastDigits))
    {
        Console.WriteLine(identifiable.Id);
    }
}
