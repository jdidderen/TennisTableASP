using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;

namespace TennisTableASP.ViewModels
{
    public class SchemasRencontresViewModel
    {
        private readonly Context _db = new Context();
        public int SrChoisi { get; set; }
        public IEnumerable<SelectListItem> SrItems
        {
            get { return _db.SchemasRencontres.Select(c => new SelectListItem() { Text = c.JoueurVisite + " - " + c.JoueurVisiteur, Value = c.SrId.ToString() }); }
        }
    }
}