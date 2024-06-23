namespace Push.Entities.Events
{
    /// <summary>
    /// Base event class
    /// </summary>
    public abstract class BaseEvent
    {
        public DateTime Timestamp { get; protected set; }
        protected BaseEvent()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
