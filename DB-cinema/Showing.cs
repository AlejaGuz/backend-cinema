using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace DB_cinema
{
    public class Showing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowID { get; set; }
        public string MovieName { get; set; }
        public int hour { get; set; }
        public int minutes { get; set; }
        public string? UrlImage { get; set; }

    }

}
