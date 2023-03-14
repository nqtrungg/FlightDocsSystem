using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("FlightDocServer")]
    public class FlightDocServer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ServerName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string ServerAddress { get; set; } = string.Empty;
    }
}
