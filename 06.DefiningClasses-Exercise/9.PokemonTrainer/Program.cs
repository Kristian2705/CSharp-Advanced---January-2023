using _9.PokemonTrainer;

string input = string.Empty;
List<Trainer> trainers = new List<Trainer>();
while((input = Console.ReadLine()) != "Tournament")
{
    string[] cmdTokens = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string trainerName = cmdTokens[0];
    string pokemonName = cmdTokens[1];
    string pokemonElement = cmdTokens[2];
    int pokemonHealth = int.Parse(cmdTokens[3]);
    if(trainers.Any(x => x.Name == trainerName))
    {
        trainers.First(x => x.Name == trainerName).Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        continue;
    }
    Trainer currTrainer = new(trainerName);
    currTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
    trainers.Add(currTrainer);
}

while((input = Console.ReadLine()) != "End")
{
    string element = input;
    foreach (var trainer in trainers)
    {
        if (trainer.Pokemons.Any(x => x.Element == element))
        {
            trainer.NumberOfBadges++;
        }
        else
        {
            foreach(var pokemon in trainer.Pokemons)
            {
                pokemon.Health -= 10;
            }
            trainer.Pokemons.RemoveAll(x => x.Health <= 0);
        }
    }
}

foreach(var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
{
    Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
}
