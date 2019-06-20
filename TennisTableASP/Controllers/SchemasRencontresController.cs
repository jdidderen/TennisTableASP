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
    public class SchemasRencontresController : Controller
    {
        private readonly Context _db = new Context();
        public ActionResult Index()
        {
            return View(GetSrList());
        }
        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Clubs/Create
        [HttpPost]
        public ActionResult Create(SchemasRencontres sr)
        {
            try
            {
                _db.SchemasRencontres.Add(sr);
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
            SchemasRencontres srUpdate = _db.SchemasRencontres.Find(id);
            return View(srUpdate);
        }
        // POST: Clubs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SchemasRencontres sr)
        {
            try
            {
                SchemasRencontres srUpdate = _db.SchemasRencontres.Find(id);
                if (srUpdate != null)
                {
                    _db.SchemasRencontres.AddOrUpdate(sr);
                    _db.SaveChanges();
                }
                else
                {
                    //Message d'erreur : Id non inexistant
                }
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
            SchemasRencontres srVm = new SchemasRencontres();
            return View(srVm);

        }
        public ActionResult ListEdit(SchemasRencontres vm)
        {
            return RedirectToAction("Edit", new { id = vm.SrId });
        }
        // GET: Clubs/Delete/5
        public ActionResult Delete(int id)
        {
            SchemasRencontres srRemove = _db.SchemasRencontres.Find(id);
            return View(srRemove);
        }
        // POST: Clubs/Delete/5
        [HttpPost]
        public ActionResult Delete(SchemasRencontres sr,int id)
        {
            try
            {
                SchemasRencontres srRemove = _db.SchemasRencontres.Find(id);
                if (srRemove != null)
                {
                    _db.SchemasRencontres.Remove(srRemove);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View(sr);
            }
        }

        public ActionResult DeleteList()
        {
            SchemasRencontresViewModel srVm = new SchemasRencontresViewModel();
            return View(srVm);

        }

        public ActionResult ListDelete(SchemasRencontres vm)
        {
            return RedirectToAction("Delete", new { id = vm.SrId });
        }

        private IQueryable<SchemasRencontres> GetSrList()
        {
            return _db.Set<SchemasRencontres>().OrderBy(c => c.SrId);
        }
    }
}
