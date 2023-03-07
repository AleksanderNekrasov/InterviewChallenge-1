using MuseumTheftCore;

namespace MuseumTheftInfrastructure
{
    public interface IStolenItemsStore : IStolenItemsRepository
    {
        void InitFromUserInput(string userInput);
    }
}