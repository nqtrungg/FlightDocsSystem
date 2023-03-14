using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("Document_Flight")]
    public class DocumentFlight
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        [ForeignKey("Flight")]
        public int FlightId { get; set; }

        public Document? Document { get; set; }

        public Flight? Flight { get; set; }
    }
}
