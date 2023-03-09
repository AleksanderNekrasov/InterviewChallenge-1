namespace MuseumTheftCore
{
    internal sealed class LootsComparer : IComparer<IStolenItemsCombination>
    {
        public int Compare(IStolenItemsCombination? x, IStolenItemsCombination? y)
        {
            if (x == null || y == null) 
                throw new ArgumentException("StolenItemsComparer. Comparable values cannot be null.");
            return x.Value.CompareTo(y.Value);
        }
    }
}
