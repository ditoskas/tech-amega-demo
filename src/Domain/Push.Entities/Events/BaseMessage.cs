using MediatR;

namespace Push.Entities.Events
{
    /// <summary>
    /// Base message class
    /// </summary>
    public abstract class BaseMessage : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        protected BaseMessage()
        {
            MessageType = GetType().Name;
        }
    }
}
