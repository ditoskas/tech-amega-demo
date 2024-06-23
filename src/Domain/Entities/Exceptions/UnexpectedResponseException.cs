namespace Entities.Exceptions
{
    public class UnexpectedResponseException : BadRequestException
    {
        public UnexpectedResponseException(string message) : base(message)
        { }
    }
}
