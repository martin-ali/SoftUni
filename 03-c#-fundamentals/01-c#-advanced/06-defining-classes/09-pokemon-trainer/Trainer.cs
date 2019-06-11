using System.Collections.Generic;

namespace _09_pokemon_trainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;

        }
        public string Name { get; private set; }

        public int BadgeCount { get; set; } = 0;

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public override string ToString()
        {
            return $"{this.Name} {this.BadgeCount} {this.Pokemons.Count}";
        }
    }
}