namespace Entities.Exceptions
{
    public class EmptyResponseException : BadRequestException
    {
        public EmptyResponseException() : base("Empty response received")
        { }
    }
}
