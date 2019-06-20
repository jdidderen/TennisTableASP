using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;

namespace TennisTableASP.ViewModels
{
    public class ClubsViewModel
    {
        private readonly Context _db = new Context();
        [DisplayName("ID du Club")]
        public int ClubChoisi { get; set; }
        [DisplayName("Club")]
        public IEnumerable<SelectListItem> ClubItems
        {
            get { return _db.Clubs.Select(c => new SelectListItem() { Text = c.Nom, Value = c.ClubId.ToString() }); }
        }
    }
}