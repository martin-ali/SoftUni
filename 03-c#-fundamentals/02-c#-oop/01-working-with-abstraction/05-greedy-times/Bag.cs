namespace _05_greedy_times
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private long capacity;

        private long itemsCount = 0;

        private Dictionary<string, Item> itemByName = new Dictionary<string, Item>();

        private Dictionary<ItemType, long> quantityByType = new Dictionary<ItemType, long>()
        {
            [ItemType.Cash] = 0,
            [ItemType.Gem] = 0,
            [ItemType.Gold] = 0
        };


        public bool IsFull => this.itemsCount == this.capacity;

        public Bag(long capacity)
        {
            this.capacity = capacity;
        }

        public int ItemsCount { get; private set; } = 0;

        private bool QuantitiesAreBalanced(Item item)
        {
            var cashQuantity = this.quantityByType[ItemType.Cash];
            var gemQuantity = this.quantityByType[ItemType.Gem];
            var goldQuantity = this.quantityByType[ItemType.Gold];

            switch (item.Type)
            {
                case ItemType.Cash: cashQuantity += item.Quantity; break;
                case ItemType.Gem: gemQuantity += item.Quantity; break;
                case ItemType.Gold: goldQuantity += item.Quantity; break;
            }

            var quantitiesAreBalanced = goldQuantity >= gemQuantity
                                    && gemQuantity >= cashQuantity;

            return quantitiesAreBalanced;
        }

        public void AddItem(Item item)
        {
            if (item.Type == ItemType.Useless
            || this.itemsCount + item.Quantity > this.capacity)
            {
                return;
            }

            if (QuantitiesAreBalanced(item))
            {
                this.quantityByType[item.Type] += item.Quantity;
                this.itemsCount += item.Quantity;

                if (this.itemByName.ContainsKey(item.Name))
                {
                    this.itemByName[item.Name].Quantity += item.Quantity;
                }
                else
                {
                    this.itemByName[item.Name] = item;
                }

            }
        }

        public override string ToString()
        {
            var itemsByType = this.itemByName.ToLookup(k => k.Value.Type, v => v.Value);

            var builder = new StringBuilder();
            foreach (var itemsGroup in itemsByType.OrderByDescending(g => this.quantityByType[g.Key]))
            {
                builder.AppendLine($"<{itemsGroup.Key}> ${this.quantityByType[itemsGroup.Key]}");

                foreach (var item in itemsGroup
                                        .OrderByDescending(i => i.Name)
                                        .ThenBy(i => i.Quantity))
                {
                    builder.AppendLine(item.ToString());
                }
            }

            return builder.ToString();
        }
    }
}