using MuseumTheftCore;
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

        /// <summary>
        /// Outputs the maximum amount of money he can get while not exceeding the bag capacity. 
        /// </summary>
        /// <param name="userInput">Input from user: a list of stolen items as a string</param>
        /// <param name="bagCapacity">Capacity of the bag</param>
        /// <returns>Maximum value possible</returns>
        public async Task<string> GetMaximumAmmountForCapacity(string userInput, int bagCapacity) 
        {
            try
            {
                //First step is to initialize data store from user input
                _dataStore.InitFromUserInput(userInput);

                //Second step is to find out all possible combinations of stolen items
                //in this step capacity of the bag is not verified
                var combinations = new StolenItemCombinations(_dataStore);

                //Third step is to initialize bag with all possible stolen items combinations
                //At this step, bag will filter out all duplicated combinations and all combinations exceeding its capacity
                var bag = Bag.CreateBagWithCapacity(bagCapacity);
                bag.AddCombinations(await combinations.GetStolenItemCombinations());

                //Finall step is to ask a bag about its maximum profit it can handle
                return bag.MaxProfitToString();
            }
            //In case input was not correct, provide user friendly message instead of exception
            catch (IncorrectStolenInputException ex)
            {
                return $"Input provided is not correct: {ex.Message}.{Environment.NewLine}Please provide a correct input";
            }
        }
    }
}