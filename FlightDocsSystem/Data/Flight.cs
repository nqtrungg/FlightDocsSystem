using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Required]
        [StringLength(50)]
        public string FlightNumber { get; set; } = string.Empty;

        [Required]
        public DateTime DepartureDate { get; set; }

        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Origin { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Destination { get; set; } = string.Empty;

        public int AircraftId { get; set; }

        [ForeignKey("AircraftId")]
        public Aircraft? Aircraft { get; set; }

        public List<DocumentFlight>? DocumentFlights { get; set; }
    }
}
