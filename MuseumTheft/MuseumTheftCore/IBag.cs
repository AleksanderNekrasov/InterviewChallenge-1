namespace MuseumTheftCore
{
    public interface IBag
    {
        bool AddCombination(IStolenItemsCombination items);
        void AddCombinations(IEnumerable<IStolenItemsCombination> itemsCombinations);
        string ToString();
    }
}