namespace MuseumTheftCore
{
    public interface IStolenItemsRepository
    {
        Task<IEnumerable<StolenItem>> GetAll();
    }
}
