using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TennisTableASP.Models
{
    public class Joueurs
    {
        [Key]
        public int JoueurId { get; set; }
        [Required, Index(IsUnique = true)]
        public int License { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public int Classement { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required]
        public int Sexe { get; set; }
        public int? Club { get; set; }
        [ForeignKey("Classement")]
        public virtual Classements ClassementId { get; set; }
        [ForeignKey("Sexe")]
        public virtual Sexes SexeId { get; set; }
        [ForeignKey("Club")]
        public virtual Clubs ClubId { get; set; }
    }
}