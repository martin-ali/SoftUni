namespace _05_greedy_times
{
    using System;
    using System.Collections.Generic;

    public class Safe
    {
        public Safe(string itemsAndQuantities)
        {
            var itemsAndQuantitiesParts = itemsAndQuantities
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < itemsAndQuantitiesParts.Length; i += 2)
            {
                var name = itemsAndQuantitiesParts[i];
                var quantity = long.Parse(itemsAndQuantitiesParts[i + 1]);

                var item = new Item(name, quantity);
                this.Items.Add(item);
            }
        }

        public List<Item> Items { get; private set; } = new List<Item>();
    }
}