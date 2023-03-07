using MuseumTheftInfrastructure;

namespace MuseumTheftApplication
{
    public sealed class FindMaxValueOfLootUseCase
    {
        private readonly IStolenItemsStore _dataStore;

        public FindMaxValueOfLootUseCase(IStolenItemsStore dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<string> GetMaximumAmmountForCapacity(string userInput, int bagCapacity) 
        {
            _dataStore.InitFromUserInput(userInput);
            var items = await _dataStore.GetAll();

            return string.Empty;
        }
    }
}