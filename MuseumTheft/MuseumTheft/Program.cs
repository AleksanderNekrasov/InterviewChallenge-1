using MuseumTheftApplication;
using MuseumTheftInfrastructure;

Console.WriteLine("In order to Calculate the maximum amount of money for the bag capacity of 40 kg.");

Console.WriteLine("Please provide an input bellow. Properties must be comma separated and items must be separated by semicolumns.");
Console.WriteLine("Example: 1,30,10;2,10,20;");
Console.WriteLine("If no items provided, default items set will be used");

var userInput = Console.ReadLine();

var inputProvided = !string.IsNullOrWhiteSpace(userInput);

var defaultInput = "1,30,10;2,10,20;3,40,30;4,20,40";

var useCase = new FindMaxValueOfLootUseCase(new StolenItemsInMemoryStore());

var input = inputProvided ? userInput ?? defaultInput : defaultInput;

//this  is an entry point to application logic
string output = await useCase
    .GetMaximumAmmountForCapacity(input, 40);

if (!inputProvided) 
{
    Console.WriteLine($"Default input was used: {defaultInput}.");
    Console.WriteLine();
}

Console.WriteLine(output);

Console.ReadLine();
