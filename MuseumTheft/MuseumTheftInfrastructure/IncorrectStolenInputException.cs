namespace MuseumTheftInfrastructure
{
    public class IncorrectStolenInputException : Exception
    {
        public IncorrectStolenInputException()
        {
        }

        public IncorrectStolenInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
