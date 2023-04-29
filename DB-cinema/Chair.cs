using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DB_cinema
{
    [Index(nameof(Number), nameof(Row), IsUnique = true, Name = "Unique_NumberRow")]
    public class Chair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChairID { get; set; }
        public int Number { get; set; }
        public char Row { get; set; }
        public int LevelID { get; set; }

        [JsonIgnore]
        [ForeignKey("LevelID")]
        public virtual LevelChair? Level { get; set; }
    }
}
