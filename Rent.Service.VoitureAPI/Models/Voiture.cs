using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rent.Service.VoitureAPI.Models
{
    [Table("Voitures")]
    public class Voiture
    {
        [Key]
        public int VoitureId { get; set; }
        [Required]
        [StringLength(20)]
        public string marque { get; set; }
        [Range(1, 8000)]
        public double PriceByDay { get; set; }
        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }
        [Required]
        public string ImageURL { get; set; }
    }
}
