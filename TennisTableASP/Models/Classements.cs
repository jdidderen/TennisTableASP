using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TennisTableASP.Models
{
    public class Classements
    {
        [Key]
        public int ClassementId { get; set; }
        [Required,Index(IsUnique = true), StringLength(3)]
        public string Classement { get; set; }
    }
}