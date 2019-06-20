using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TennisTableASP.Views.Shared;

namespace TennisTableASP.Models
{
    public class SchemasRencontres
    {
        [Key]
        public int SrId { get; set; }
        [Required]
        [Range(1,50)]
        [Index("Type_Ordre",1,IsUnique = true)]
        public int Ordre { get; set; }
        [Required]
        [Index("Type_Ordre",2, IsUnique = true)]
        [StringLength(30)]
        public string Type { get; set; }
        [Required]
        [Range(1, 4)]
        public int JoueurVisite { get; set; }
        [Required]
        [Range(1, 4)]
        public int JoueurVisiteur { get; set; }
    }

}