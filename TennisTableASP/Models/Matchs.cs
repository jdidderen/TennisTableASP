using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace TennisTableASP.Models
{
    public class Matchs
    {
        [Key]
        public int MatchId { get; set; }
        [Required, Index(IsUnique = true)]
        public int NumMatch { get; set; }
        [Required,DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required, DataType(DataType.Time)]
        public DateTime HeureDebut { get; set; }
        [DataType(DataType.Time)]
        public DateTime? HeureFin { get; set; }
        public int? CapitaineVisite { get; set; }
        public int? CapitaineVisiteur { get; set; }
        public string JugeArbitre { get; set; }
        public string Division { get; set; }
        public string LettreVisite { get; set; }
        public string LettreVisiteur { get; set; }
        [Required]
        public int ClubVisite { get; set; }
        [Required]
        public int ClubVisiteur { get; set; }
        public int? J1Visiteur { get; set; }
        public int? J2Visiteur { get; set; }
        public int? J3Visiteur { get; set; }
        public int? J4Visiteur { get; set; }
        public int? J1Visite { get; set; }
        public int? J2Visite { get; set; }
        public int? J3Visite { get; set; }
        public int? J4Visite { get; set; }
        [Required]
        public int SerieId { get; set; }
        
        [ForeignKey("ClubVisite")]
        public virtual Clubs ClubVr { get; set; }
        [ForeignKey("ClubVisiteur")]
        public virtual Clubs ClubVe { get; set; }
        [ForeignKey("J1Visiteur")]
        public virtual Joueurs JVr1 { get; set; }
        [ForeignKey("J2Visiteur")]
        public virtual Joueurs JVr2 { get; set; }
        [ForeignKey("J3Visiteur")]
        public virtual Joueurs JVr3 { get; set; }
        [ForeignKey("J4Visiteur")]
        public virtual Joueurs JVr4 { get; set; }
        [ForeignKey("J1Visite")]
        public virtual Joueurs JVe1 { get; set; }
        [ForeignKey("J2Visite")]
        public virtual Joueurs JVe2 { get; set; }
        [ForeignKey("J3Visite")]
        public virtual Joueurs JVe3 { get; set; }
        [ForeignKey("J4Visite")]
        public virtual Joueurs JVe4 { get; set; }
        [ForeignKey("CapitaineVisite")]
        public virtual Joueurs CapitaineVe { get; set; }
        [ForeignKey("CapitaineVisiteur")]
        public virtual Joueurs CapitaineVr { get; set; }
        [ForeignKey("SerieId")]
        public virtual Series Serie { get; set; }
    }
}