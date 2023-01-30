using _4.OpinionPoll;

int n = int.Parse(Console.ReadLine());

List<Person> people = new List<Person>();

for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = input[0];
    int age = int.Parse(input[1]);
    people.Add(new Person(name, age));
}

foreach(Person person in people.OrderBy(x => x.Name))
{
    if(person.Age > 30)
    {
        Console.WriteLine($"{person.Name} - {person.Age}");
    }
}
