using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("UserDocument")]
    public class UserDocument
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        public User? User { get; set; }

        public Document? Document { get; set; }
    }
}
