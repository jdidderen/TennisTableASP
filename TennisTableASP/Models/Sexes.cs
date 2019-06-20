using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace TennisTableASP.Models
{
    public class Sexes
    {
        [Key]
        public int SexeId { get; set; }
        [Required, Index(IsUnique = true),StringLength(15)]
        public string Denomination { get; set; }
    }
}