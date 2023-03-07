namespace MuseumTheftCore
{
    public sealed class Bag
    {
        private readonly int _bagCapacity;
        private readonly ISet<IStolenItemsCombination> _possibleItemsCombinations;

        private Bag(int bagCapacity) 
        { 
            _bagCapacity = bagCapacity;
            _possibleItemsCombinations = new SortedSet<IStolenItemsCombination>(new LootsComparer());
        }

        public static Bag CreateBagWithCapacity(int bagCapacity) => new (bagCapacity);

        public bool AddCombination(IStolenItemsCombination items) 
        {
            if (items.Weight > _bagCapacity) return false;

            return _possibleItemsCombinations.Add(items);
        }

        private IStolenItemsCombination MaxLoot() => _possibleItemsCombinations.Last();

        public override string ToString()
        {
            var maxLoot = MaxLoot();
            return $"maximum profit is {maxLoot.Value}, the weights of items are: {maxLoot.WeightsOfItems()}";
        }
    }
}