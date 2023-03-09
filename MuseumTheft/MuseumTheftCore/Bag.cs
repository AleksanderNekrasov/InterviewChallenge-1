namespace MuseumTheftCore
{
    public sealed class Bag : IBag
    {
        private readonly int _bagCapacity;
        private readonly ISet<IStolenItemsCombination> _possibleItemsCombinations;

        private Bag(int bagCapacity)
        {
            _bagCapacity = bagCapacity;
            _possibleItemsCombinations = new SortedSet<IStolenItemsCombination>(new LootsComparer());
        }

        public static Bag CreateBagWithCapacity(int bagCapacity) => new(bagCapacity);

        public void AddCombinations(IEnumerable<IStolenItemsCombination> itemsCombinations)
        {
            foreach (var combination in itemsCombinations)
            {
                AddCombination(combination);
            }
        }

        /// <summary>
        /// Add unique combination of stolen items to the bag.
        /// </summary>
        /// <param name="items">Items to add</param>
        /// <returns>Returns false if combination is not unique.</returns>
        public bool AddCombination(IStolenItemsCombination items)
        {
            if (items.Weight > _bagCapacity) return false;

            return _possibleItemsCombinations.Add(items);
        }

        private IStolenItemsCombination MaxLoot() => 
            _possibleItemsCombinations.Last();

        public string MaxProfitToString()
        {
            var maxLoot = MaxLoot();
            return $"Maximum profit is {maxLoot.Value}, the weights of items are: {maxLoot.WeightsOfItems()}.";
        }
    }
}