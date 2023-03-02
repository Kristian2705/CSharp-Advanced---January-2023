using _4.BorderControl;
using _5.BirthdayCelebs;

string input = string.Empty;
List<IBirthable> givenBirth = new();

while((input = Console.ReadLine()) != "End")
{
    string[] info = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string type = info[0];

    if(type == "Citizen")
    {
        IBirthable person = new Person(info[1], int.Parse(info[2]), info[3], info[4]);
        givenBirth.Add(person);
    }
    else if(type == "Pet")
    {
        IBirthable pet = new Pet(info[1], info[2]);
        givenBirth.Add(pet);
    }
}

string year = Console.ReadLine();

foreach(var somethingGivenBirth in givenBirth)
{
    if (somethingGivenBirth.Birthdate.EndsWith(year))
    {
        Console.WriteLine(somethingGivenBirth.Birthdate);
    }
}
