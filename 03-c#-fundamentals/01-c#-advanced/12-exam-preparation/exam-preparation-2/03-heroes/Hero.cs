using System;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            var profile = $"Hero: {this.Name} - {this.Level}lvl{Environment.NewLine}{this.Item}".Trim();

            return profile;
        }
    }
}