using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightDocsSystem.Data
{
    [Table("ServerDocument")]
    public class ServerDocument
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FlightDocServer")]
        public int ServerId { get; set; }

        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        public FlightDocServer? FlightDocServer { get; set; }

        public Document? Document { get; set; }
    }
}
