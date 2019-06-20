using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisTableASP.Models;
using TennisTableASP.ViewModels;

namespace TennisTableASP.Controllers
{
    public class ClassementsController : Controller
    {
        private readonly Context _db = new Context();
        // GET: Classements
        public ActionResult Index()
        {
            return View(GetClassementsList());
        }
        // GET: Classements/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Classements/Create
        [HttpPost]
        public ActionResult Create(Classements c)
        {
            try
            {
                _db.Classements.Add(c);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(c);
            }
        }
        // GET: Classements/Edit/5
        public ActionResult Edit(int id)
        {
            Classements classeUpdate = _db.Classements.FirstOrDefault(c => c.ClassementId == id);
            return View(classeUpdate);
        }
        // POST: Classements/Edit/5
        [HttpPost]
        public ActionResult Edit(Classements c,int id)
        {
            try
            {
                Classements classeUpdate = _db.Classements.Find(id);
                if (classeUpdate != null)
                {
                    classeUpdate.Classement = c.Classement;
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
        [HttpGet]
        public ActionResult EditList()
        {
            ClassementsViewModel classementsVm = new ClassementsViewModel();
            return View(classementsVm);

        }
        public ActionResult ListEdit(ClassementsViewModel vm)
        {
            return RedirectToAction("Edit", new { id = vm.ClassementChoisi });
        }
        // GET: Classements/Delete/5
        public ActionResult Delete(int id)
        {
            Classements classeRemove = _db.Classements.FirstOrDefault(c => c.ClassementId == id);
            return View(classeRemove);
        }
        // POST: Classements/Delete/5
        [HttpPost]
        public ActionResult Delete(Classements c,int id)
        {
            try
            {
                Classements classeRemove = _db.Classements.Find(id);
                if (classeRemove != null)
                {
                    _db.Classements.Remove(classeRemove);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteList()
        {
            ClassementsViewModel classementsVm = new ClassementsViewModel();
            return View(classementsVm);

        }
        public ActionResult ListDelete(ClassementsViewModel vm)
        {
            return RedirectToAction("Delete", new { id = vm.ClassementChoisi });
        }
        [NonAction]
        private IQueryable<Classements> GetClassementsList()
        {
            return _db.Set<Classements>().OrderBy(c => c.ClassementId);
        }
    }
}
