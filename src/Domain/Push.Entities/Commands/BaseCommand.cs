using Push.Entities.Events;

namespace Push.Entities.Commands
{
    /// <summary>
    /// Base command class
    /// </summary>
    public abstract class BaseCommand : BaseMessage
    {
        public DateTime Timestamp { get; protected set; }

        protected BaseCommand()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
