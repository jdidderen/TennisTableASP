using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;

namespace TennisTableASP.ViewModels
{
    public class SeriesViewModel
    {
        private readonly Context _db = new Context();
        public int SerieChoisi { get; set; }
        public IEnumerable<SelectListItem> SerieItems
        {
            get { return _db.Series.Select(c => new SelectListItem() { Text = c.Denomination, Value = c.SerieId.ToString() }); }
        }
    }
}