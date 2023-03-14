using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("Aircraft")]
    public class Aircraft
    {
        [Key]
        public int AircraftId { get; set; }

        [Required]
        [StringLength(50)]
        public string? AircraftType { get; set; }

        [Required]
        [StringLength(50)]
        public string? Manufacturer { get; set; }

        [Required]
        [StringLength(50)]
        public string? Model { get; set; }

        [Required]
        [StringLength(50)]
        public string? RegistrationNumber { get; set; }
    }
}
