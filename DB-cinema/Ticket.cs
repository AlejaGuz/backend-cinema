using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DB_cinema
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }       
        public int IdShowing { get; set; }
        public int IdChair { get; set; }

        
        [JsonIgnore]
        [ForeignKey("IdShowing")]
        public virtual Showing? Show { get; set; }
        [JsonIgnore]
        [ForeignKey("IdChair")]
        public virtual Chair? Chair { get; set; }

        [JsonIgnore]
        public virtual Sale? Sale { get; set; }

    }
}
