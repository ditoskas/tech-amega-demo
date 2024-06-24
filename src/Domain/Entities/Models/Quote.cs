using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Quote : BaseModelWithTimestamps
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Symbol { get; set; }
        public DateTimeOffset Ts { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Mid { get; set; }
    }
}
