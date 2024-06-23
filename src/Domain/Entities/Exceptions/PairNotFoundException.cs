namespace Entities.Exceptions
{
    public class PairNotFoundException : NotFoundException
    {
        public PairNotFoundException(string pair) : base($"Pair {pair} not found")
        {
        }
    }
}
