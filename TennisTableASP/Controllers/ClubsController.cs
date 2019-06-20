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
    public class ClubsController : Controller
    {
        private readonly Context _db = new Context();
        // GET: Clubs
        public ActionResult Index()
        {
            return View(GetClubsList());
        }
        // GET: Clubs/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Clubs/Create
        [HttpPost]
        public ActionResult Create(Clubs c)
        {
            try
            {
                _db.Clubs.Add(c);
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
            Clubs clubUpdate = _db.Clubs.Find(id);
            return View(clubUpdate);
        }
        // POST: Clubs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Clubs c)
        {
            try
            {
                Clubs clubUpdate = _db.Clubs.Find(id);
                if (clubUpdate != null)
                {
                    clubUpdate.Nom = c.Nom;
                    clubUpdate.Adresse = c.Adresse;
                    clubUpdate.CodePostal = c.CodePostal;
                    clubUpdate.Indice = c.Indice;
                    clubUpdate.NomCourt = c.NomCourt;
                    clubUpdate.Numero = c.Numero;
                    clubUpdate.Ville = c.Ville;
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
            ClubsViewModel matchsVm = new ClubsViewModel();
            return View(matchsVm);

        }
        public ActionResult ListEdit(ClubsViewModel vm)
        {
            return RedirectToAction("Edit", new { id = vm.ClubChoisi });
        }
        // GET: Clubs/Delete/5
        public ActionResult Delete(int id)
        {
            Clubs clubRemove = _db.Clubs.Find(id);
            return View(clubRemove);
        }
        // POST: Clubs/Delete/5
        [HttpPost]
        public ActionResult Delete(Clubs c,int id)
        {
            try
            {
                Clubs clubRemove = _db.Clubs.Find(id);
                if (clubRemove != null)
                {
                    _db.Clubs.Remove(clubRemove);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View(c);
            }
        }

        public ActionResult DeleteList()
        {
            ClubsViewModel matchsVm = new ClubsViewModel();
            return View(matchsVm);

        }

        public ActionResult ListDelete(ClubsViewModel vm)
        {
            return RedirectToAction("Delete", new { id = vm.ClubChoisi });
        }

        private IQueryable<Clubs> GetClubsList()
        {
            return _db.Set<Clubs>().OrderBy(c => c.ClubId);
        }
    }
}
