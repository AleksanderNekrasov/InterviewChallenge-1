namespace MuseumTheftInfrastructure
{
    public class IncorrectInputException : Exception
    {
        public IncorrectInputException()
        {
        }

        public IncorrectInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
