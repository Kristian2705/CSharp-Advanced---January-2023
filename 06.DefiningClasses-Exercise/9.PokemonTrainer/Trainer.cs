using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get { return name; } set { name = value; } }
        public int NumberOfBadges { get { return numberOfBadges; } set { numberOfBadges = value; } }
        public List<Pokemon> Pokemons { get { return pokemons; } set { pokemons = value; } }
    }
}
