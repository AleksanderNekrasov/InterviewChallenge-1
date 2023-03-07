namespace MuseumTheftCore
{
    public interface IStolenItemsCombination
    {
        int Value { get; }

        int Weight { get; }

        bool AddItem(StolenItem item);

        string WeightsOfItems();
    }
}