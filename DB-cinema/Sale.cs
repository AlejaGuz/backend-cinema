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
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleID { get; set; }
        public DateTime Date { get; set; }
        
        public int ShowingID { get; set; }
        public double SaleValue { get; set; }

        [JsonIgnore]
        [ForeignKey("ShowingID")]
        public virtual Showing? Show { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        
    }
}
