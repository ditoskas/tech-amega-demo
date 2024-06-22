namespace Entities.Models
{
    /// <summary>
    /// Base model for timestamped models
    /// </summary>
    public abstract class BaseModelWithTimestamps : BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
