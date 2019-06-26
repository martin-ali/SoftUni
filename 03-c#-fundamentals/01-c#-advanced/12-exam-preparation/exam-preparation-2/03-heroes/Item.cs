namespace Heroes
{
    public class Item
    {
        internal Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public override string ToString()
        {
            return $@"Item:
 * Strength: {this.Strength}
 * Ability: {this.Ability}
 * Intelligence: {this.Intelligence}";
        }
    }
}