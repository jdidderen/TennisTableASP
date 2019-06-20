using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public class JoueursController : Controller
    {
        private readonly Context _db = new Context();
        public ActionResult Index()
        {
            return View(GetJoueursList());
        }
        public ActionResult Create()
        {
            JoueursViewModel joueurVm = new JoueursViewModel
            {
                Joueurs = new Joueurs(),
                ClassesVm = new ClassementsViewModel(),
                ClubVm = new ClubsViewModel(),
                SexeVm = new SexesViewModel()
            };
            return View(joueurVm);
        }
        [HttpPost]
        public ActionResult Create(JoueursViewModel jVm)
        {
            try
            {
                jVm.Joueurs.Classement = jVm.ClassesVm.ClassementChoisi;
                jVm.Joueurs.Club = jVm.ClubVm.ClubChoisi;
                jVm.Joueurs.Sexe = jVm.SexeVm.SexeChoisi;
                _db.Joueurs.Add(jVm.Joueurs);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Debug.Write("Test : "+validationError.PropertyName+" "+validationError.ErrorMessage);
                    }
                }
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            JoueursViewModel joueurVm = new JoueursViewModel
            {
                Joueurs = new Joueurs(),
                ClassesVm = new ClassementsViewModel(),
                ClubVm = new ClubsViewModel(),
                SexeVm = new SexesViewModel()
            };
            joueurVm.Joueurs = _db.Joueurs.Find(id);
            return View(joueurVm);
        }
        [HttpPost]
        public ActionResult Edit(int id, JoueursViewModel jVm)
        {
            try
            {
                Joueurs joueurUpdate = _db.Joueurs.Find(id);
                joueurUpdate.Club = jVm.ClubVm.ClubChoisi;
                joueurUpdate.Classement = jVm.ClassesVm.ClassementChoisi;
                joueurUpdate.Nom = jVm.Joueurs.Nom;
                joueurUpdate.Prenom = jVm.Joueurs.Prenom;
                joueurUpdate.License = jVm.Joueurs.License;
                joueurUpdate.Mail = jVm.Joueurs.Mail;
                joueurUpdate.Sexe = jVm.SexeVm.SexeChoisi;
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
            JoueursViewModel joueursVm = new JoueursViewModel();
            return View(joueursVm);

        }
        public ActionResult ListEdit(JoueursViewModel vm)
        {
            return RedirectToAction("Edit", new { id = vm.JoueurChoisi });
        }
        public ActionResult Delete(int id)
        {
            var joueurRemove = _db.Joueurs.Where(m => m.JoueurId == id).Include(m => m.ClassementId).Include(m => m.ClubId).Include(m => m.SexeId).FirstOrDefault();
            return View(joueurRemove);
        }
        [HttpPost]
        public ActionResult Delete(Joueurs j,int id)
        {
            try
            {
                Joueurs joueurRemove = _db.Joueurs.Find(id);
                if (joueurRemove != null)
                {
                    _db.Joueurs.Remove(joueurRemove);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View(j);
            }
        }
        public ActionResult DeleteList()
        {
            JoueursViewModel joueursVm = new JoueursViewModel();
            return View(joueursVm);

        }
        public ActionResult ListDelete(JoueursViewModel vm)
        {
            return RedirectToAction("Delete", new { id = vm.JoueurChoisi });
        }
        private IQueryable<Joueurs> GetJoueursList()
        {
            return _db.Joueurs.Include(m => m.ClassementId).Include(m => m.ClubId).Include(m => m.SexeId);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListeJoueursClubs(int id)
        {
            var joueurs = _db.Joueurs.Where(j => j.Club == id).Select(j => new {j.JoueurId, j.Nom, j.Prenom});
            return Json(joueurs, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ClassementJoueur(int id)
        {
            var classement = _db.Joueurs.Where(j => j.JoueurId == id).Include(c => c.ClassementId).Select(c => c.ClassementId.Classement).FirstOrDefault();
            return Json(classement, JsonRequestBehavior.AllowGet);
        }
    }
}
