using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TennisTableASP.Models
{
    public class Clubs
    {
        [Key]
        public int ClubId { get; set; }
        [Required, Index(IsUnique = true),StringLength(10)]
        public string Indice { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string NomCourt { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required,DataType(DataType.PostalCode),Range(1000,9999)]
        public int CodePostal { get; set; }
        [Required]
        public string Ville { get; set; }
    }
}