using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("Document")]
    public class Document
    {
        [Key]
        [Column("document_id")]
        public int DocumentId { get; set; }

        [Column("document_name")]
        [StringLength(255)]
        public string? DocumentName { get; set; }

        [Column("document_type")]
        [StringLength(50)]
        public string? DocumentType { get; set; }

        [Column("version")]
        public int Version { get; set; }

        [Column("departure_date")]
        public DateTime? DepartureDate { get; set; }

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; }

        [Column("creator")]
        [StringLength(50)]
        public string? Creator { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        public List<DocumentFlight>? DocumentFlights { get; set; }
    }
}
