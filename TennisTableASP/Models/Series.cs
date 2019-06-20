using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace TennisTableASP.Models
{
    public class Series
    {
        [Key]
        public int SerieId { get; set; }
        [Required]
        public string Denomination { get; set; }
        [Required]
        public string Type { get; set; }
    }
}