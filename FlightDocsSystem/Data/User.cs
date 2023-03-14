using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? UserType { get; set; }

        [Required]
        [StringLength(50)]
        public string? Username { get; set; }

        [Required]
        [StringLength(50)]
        public string? Password { get; set; }

        [Required]
        [StringLength(255)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(255)]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string? UserRole { get; set; }
    }
}
