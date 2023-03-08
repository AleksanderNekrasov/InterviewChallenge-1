﻿using System.Linq;

namespace MuseumTheftCore
{
    public sealed class Loot : IStolenItemsCombination
    {
        private readonly HashSet<StolenItem> _stolenItems;

        public Loot()
        {
            _stolenItems = new HashSet<StolenItem>();
        }

        public Loot(IEnumerable<StolenItem> items) : this()
        {
            foreach (var item in items) 
            {
                AddItem(item);
            }
        }

        public bool AddItem(StolenItem item) =>
            _stolenItems.Add(item);

        public string WeightsOfItems() =>
            string.Join(", ", _stolenItems.Select(x => $"{x.Weight}kg"));
        
        public int Value => _stolenItems.Sum(x => x.Value);

        public int Weight => _stolenItems.Sum(x => x.Weight);
    }
}
