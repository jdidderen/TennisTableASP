using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;

namespace TennisTableASP.ViewModels
{
    public class JoueursViewModel
    {
        private readonly Context _db = new Context();
        public Joueurs Joueurs { get; set; }
        public ClassementsViewModel ClassesVm { get; set; }
        public SexesViewModel SexeVm { get; set; }
        public ClubsViewModel ClubVm { get; set; }
        public int JoueurChoisi { get; set; }
        public IEnumerable<SelectListItem> JoueurItems
        {
            get { return _db.Joueurs.Select(c => new SelectListItem() { Text = c.Nom + " " + c.Prenom, Value = c.JoueurId.ToString() }); }
        }
    }
}