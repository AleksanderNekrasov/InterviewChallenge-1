using MuseumTheftCore;

namespace MuseumTheftInfrastructure
{
    public sealed class StolenItemsInMemoryStore : IStolenItemsStore
    {
        private IEnumerable<StolenItem>? _stolenItems;

        public void InitFromUserInput(string userInput)
        {
            try
            {
                //Materialize enumerable here for error handling
                _stolenItems = ParceUserInput(userInput)
                    .ToArray();
            }

            catch (IndexOutOfRangeException e)
            {
                throw new IncorrectStolenInputException("For each stolen item 3 properties must be provided comma separated", e);
            }
            catch (System.FormatException e)
            {
                throw new IncorrectStolenInputException("Properties of stolen item must be an interger and comma separated", e);
            }
        }

        public async Task<IEnumerable<StolenItem>> GetAll() => 
            // in other implementations of interface this will be an async call to a data source
            // in current implementation data source is inmemory
            await Task.FromResult(_stolenItems);
   
        private IEnumerable<StolenItem> ParceUserInput(string userInput)
        {
            var itemsAsText = userInput.Split(';');
            foreach (var item in itemsAsText)
            {
                var propertiesOfItem = item.Split(",");

                yield return new StolenItem(
                    int.Parse(propertiesOfItem[0]),
                    int.Parse(propertiesOfItem[1]),
                    int.Parse(propertiesOfItem[2]));
            }
        }
    }
}
