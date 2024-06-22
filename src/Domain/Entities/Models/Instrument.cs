using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Instrument : BaseModelWithTimestamps
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Customer name is a required field.")]
        [MaxLength(45, ErrorMessage = "Maximum length for the name is 45 characters.")]
        public string Symbol { get; set; }

        [MaxLength(255, ErrorMessage = "Maximum length of description is 255 characters.")]
        public string? Description { get; set; }

        [MaxLength(512, ErrorMessage = "Maximum length of image path is 512 characters.")]
        public string? ImagePath { get; set; }
    }
}
