namespace MuseumTheftCore
{
    public interface IStolenItemCombinations
    {
        Task<IEnumerable<Loot>> GetStolenItemCombinations();
    }
}