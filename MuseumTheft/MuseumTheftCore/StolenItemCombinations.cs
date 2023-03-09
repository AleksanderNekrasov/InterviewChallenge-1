namespace MuseumTheftCore
{
    public sealed class StolenItemCombinations
    {
        private readonly IStolenItemsRepository _repo;

        public StolenItemCombinations(IStolenItemsRepository repo) 
            => _repo = repo;

        public async Task<IEnumerable<Loot>> GetStolenItemCombinations()
        {
            var stolenItems = await _repo.GetAll();
            var idsOfItems = FindNumberCombinations(stolenItems.Select(x => x.ItemNumber).ToArray());
            return PopulatePossibleLoots(idsOfItems, stolenItems);
        }

        private IEnumerable<Loot> PopulatePossibleLoots(IEnumerable<IEnumerable<int>> numsOfStolenItems, IEnumerable<StolenItem> stolenItems) 
        {
            foreach (var nums in numsOfStolenItems) 
            {
                if (!nums.Any()) continue;

                yield return new Loot(stolenItems
                        .Where(x => 
                            nums.Contains(x.ItemNumber)));
            }
        }

        private static IEnumerable<int[]> FindNumberCombinations(IEnumerable<int> stolenItems)  
            => Enumerable.Range(0, 1 << (stolenItems.Count()))
                .Select(index => stolenItems.Where((v, i) => (index & (1 << i)) != 0).ToArray());        

    }
}
