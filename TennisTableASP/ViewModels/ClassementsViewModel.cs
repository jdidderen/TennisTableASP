using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;

namespace TennisTableASP.ViewModels
{
    public class ClassementsViewModel
    {
        private readonly Context _db = new Context();
        public int ClassementChoisi { get; set; }
        public IEnumerable<SelectListItem> ClassementItems
        {
            get { return _db.Classements.Select(c => new SelectListItem() { Text = c.Classement, Value = c.ClassementId.ToString() }); }
        }
    }
}