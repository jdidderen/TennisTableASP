using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;

namespace TennisTableASP.ViewModels
{
    public class MatchsViewModel
    {
        private readonly Context _db = new Context();
        public Matchs Matchs { get; set; }
        public SeriesViewModel SeriesVm { get; set; }
        public ClubsViewModel ClubsVrVm { get; set; }
        public ClubsViewModel ClubsVeVm { get; set; }
        public JoueursViewModel Joueur1Ve { get; set; }
        public JoueursViewModel Joueur2Ve { get; set; }
        public JoueursViewModel Joueur3Ve { get; set; }
        public JoueursViewModel Joueur4Ve { get; set; }
        public JoueursViewModel Joueur1Vr { get; set; }
        public JoueursViewModel Joueur2Vr { get; set; }
        public JoueursViewModel Joueur3Vr { get; set; }
        public JoueursViewModel Joueur4Vr { get; set; }
        public JoueursViewModel CapitaineVr { get; set; }
        public JoueursViewModel CapitaineVe { get; set; }
        public int MatchChoisi { get; set; }
        public List<Rencontres> ListeRencontres { get; set; }
        public string ScoreIndiv { get; set; }
        public IEnumerable<SelectListItem> MatchItems
        {
            get { return _db.Matchs.Select(c => new SelectListItem() { Text = c.ClubVe.NomCourt + "-" + c.ClubVr.NomCourt, Value = c.MatchId.ToString() }); }
        }
    }
}