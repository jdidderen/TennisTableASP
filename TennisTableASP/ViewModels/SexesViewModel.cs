using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;

namespace TennisTableASP.ViewModels
{
    public class SexesViewModel
    {
        private readonly Context _db = new Context();
        public int SexeChoisi { get; set; }
        public IEnumerable<SelectListItem> SexeItems
        {
            get { return _db.Sexes.Select(c => new SelectListItem() { Text = c.Denomination, Value = c.SexeId.ToString() }); }
        }
    }
}