using System.Collections.Generic;

namespace _11_pokemon_trainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.BadgeCount = 0;
            this.Pokemon = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int BadgeCount { get; set; }

        public List<Pokemon> Pokemon { get; set; }
    }
}