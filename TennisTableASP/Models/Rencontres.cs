using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TennisTableASP.Models
{
    public class Rencontres
    {
        [Key]
        public int RencId { get; set; }
        [Required]
        public int MatchId { get; set; }
        [Required]
        public int SrId { get; set; }
        public string Score { get; set; }
        [ForeignKey("MatchId")]
        public virtual Matchs Match { get; set; }
        [ForeignKey("SrId")]
        public virtual SchemasRencontres Sr { get; set; }
    }
}