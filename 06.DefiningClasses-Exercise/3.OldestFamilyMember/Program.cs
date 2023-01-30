using _3.OldestFamilyMember;

int n = int.Parse(Console.ReadLine());

Family family = new Family();

for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = input[0];
    int age = int.Parse(input[1]);
    Person person = new Person(name, age);
    family.AddMember(person);
}

Person oldest = family.GetOldestMember();
Console.WriteLine($"{oldest.Name} {oldest.Age}");
