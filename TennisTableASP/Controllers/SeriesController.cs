using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;
using TennisTableASP.ViewModels;

namespace TennisTableASP.Controllers
{
    public class SeriesController : Controller
    {
        private readonly Context _db = new Context();
        // GET: Clubs
        public ActionResult Index()
        {
            return View(GetSeriesList());
        }
        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Clubs/Create
        [HttpPost]
        public ActionResult Create(Series s)
        {
            try
            {
                _db.Series.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Clubs/Edit/5
        public ActionResult Edit(int id)
        {
            Series serieUpdate = _db.Series.Find(id);
            return View(serieUpdate);
        }
        // POST: Clubs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Series s)
        {
            try
            {
                Series serieUpdate = _db.Series.Find(id);
                if (serieUpdate != null)
                {
                    serieUpdate.Type = s.Type;
                    serieUpdate.Denomination = s.Denomination;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(s);
                }
            }
            catch
            {
                //Message d'erreur : Problème
                return View();
            }
        }
        public ActionResult EditList()
        {
            SeriesViewModel seriesVm = new SeriesViewModel();
            return View(seriesVm);

        }
        public ActionResult ListEdit(SeriesViewModel vm)
        {
            return RedirectToAction("Edit", new { id = vm.SerieChoisi });
        }
        // GET: Clubs/Delete/5
        public ActionResult Delete(int id)
        {
            Series serieRemove = _db.Series.Find(id);
            return View(serieRemove);
        }
        // POST: Clubs/Delete/5
        [HttpPost]
        public ActionResult Delete(Series s,int id)
        {
            try
            {
                Series serieRemove = _db.Series.Find(id);
                if (serieRemove != null)
                {
                    _db.Series.Remove(serieRemove);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View(s);
            }
        }

        public ActionResult DeleteList()
        {
            SeriesViewModel seriesVm = new SeriesViewModel();
            return View(seriesVm);

        }

        public ActionResult ListDelete(SeriesViewModel vm)
        {
            return RedirectToAction("Delete", new { id = vm.SerieChoisi });
        }

        private IQueryable<Series> GetSeriesList()
        {
            return _db.Set<Series>().OrderBy(c => c.SerieId);
        }
    }
}
