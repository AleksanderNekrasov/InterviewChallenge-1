using MuseumTheftApplication;
using MuseumTheftInfrastructure;

var userInput = "1,30,10;2,10,20;3,40,30;4,20,40";

var useCase = new FindMaxValueOfLootUseCase(new StolenItemsInMemoryStore());

var output = useCase.GetMaximumAmmountForCapacity(userInput, 40);

Console.WriteLine("Hello, World!");
