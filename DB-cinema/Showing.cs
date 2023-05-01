using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace DB_cinema
{
    public class Showing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowID { get; set; }
        public string MovieName { get; set; }
        public int ScheduleID { get; set; }
        public string? UrlImage { get; set; }

        [JsonIgnore]
        [ForeignKey("ScheduleID")]
        public virtual Schedule? Schedule { get; set; }

    }

}
