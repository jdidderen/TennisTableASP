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
    public class SexesController : Controller
    {
        private readonly Context _db = new Context();
        public ActionResult Index()
        {
            return View(GetSexesList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sexes s)
        {
            try
            {
                _db.Sexes.Add(s);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Sexes sexeUpdate = _db.Sexes.Find(id);
            return View(sexeUpdate);
        }
        [HttpPost]
        public ActionResult Edit(int id, Sexes s)
        {
            try
            {
                Sexes sexeUpdate = _db.Sexes.Find(id);
                sexeUpdate.Denomination = s.Denomination;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                //Message d'erreur : Problème
                return View();
            }
        }
        public ActionResult EditList()
        {
            SexesViewModel sexesVm = new SexesViewModel();
            return View(sexesVm);

        }
        public ActionResult ListEdit(SexesViewModel vm)
        {
            return RedirectToAction("Edit", new { id = vm.SexeChoisi });
        }
        // GET: Clubs/Delete/5
        public ActionResult Delete(int id)
        {
            Sexes sexeRemove = _db.Sexes.Find(id);
            return View(sexeRemove);
        }
        // POST: Clubs/Delete/5
        [HttpPost]
        public ActionResult Delete(Sexes s,int id)
        {
            try
            {
                Sexes sexeRemove = _db.Sexes.Find(id);
                if (sexeRemove != null)
                {
                    _db.Sexes.Remove(sexeRemove);
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
            SexesViewModel sexesVm = new SexesViewModel();
            return View(sexesVm);

        }

        public ActionResult ListDelete(SexesViewModel vm)
        {
            return RedirectToAction("Delete", new { id = vm.SexeChoisi });
        }

        private IQueryable<Sexes> GetSexesList()
        {
            return _db.Set<Sexes>().OrderBy(c => c.SexeId);
        }
    }
}
