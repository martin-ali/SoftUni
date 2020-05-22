namespace _05_greedy_times
{
    public class Item
    {
        public Item(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Type = Item.GetType(name);
        }

        public string Name { get; private set; }

        public ItemType Type { get; private set; }

        public long Quantity { get; set; }

        private static ItemType GetType(string name)
        {
            var type = ItemType.Useless;

            if (name.Length == 3)
            {
                type = ItemType.Cash;
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                type = ItemType.Gem;
            }
            else if (name.ToLower() == "gold")
            {
                type = ItemType.Gold;
            }

            return type;
        }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Quantity}";
        }
    }
}