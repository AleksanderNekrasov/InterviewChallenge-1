using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumTheftCore
{
    public class StolenItemCombinations
    {
        private readonly IEnumerable<StolenItem> _stolenItems;
        private readonly IList<Loot> _possibleLoots;

        public StolenItemCombinations(IEnumerable<StolenItem> stolenItems) 
        {
            _stolenItems = stolenItems;
            _possibleLoots = new List<Loot>();
            var idsOfItems = FindNumberCombinations(stolenItems.Select(x => x.ItemNumber).ToArray(), new List<int> ());
            PopulatePossibleLoots(idsOfItems);
        }

        public IEnumerable<Loot> GetStolenItemCombinations => _possibleLoots;

        private void PopulatePossibleLoots(IEnumerable<IEnumerable<int>> numsOfStolenItems) 
        {
            foreach (var nums in numsOfStolenItems) 
            {
                if (nums.Count() == 0) continue;

                _possibleLoots
                    .Add(new Loot(_stolenItems
                        .Where(x => 
                            nums.Contains(x.ItemNumber))));
            }
        }

        private IEnumerable<int[]> FindNumberCombinations(IEnumerable<int> stolenItems, List<int> temp)  
            => Enumerable.Range(0, 1 << (stolenItems.Count()))
                .Select(index => stolenItems.Where((v, i) => (index & (1 << i)) != 0).ToArray());        

    }
}
