using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class InstrumentPair : BaseModelWithTimestamps
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey(nameof(Instrument))]
        public long BaseInstrumentId { get; set; }

        [ForeignKey(nameof(Instrument))]
        public long NonBaseInstrumentId { get; set; }

        public Instrument BaseInstrument { get; set; }
        public Instrument NonBaseInstrument { get; set; }

        public string GetPair() => $"{BaseInstrument?.Symbol.ToUpper()}-{NonBaseInstrument?.Symbol.ToUpper()}";
    }
}
