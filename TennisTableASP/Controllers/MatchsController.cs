using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using TennisTableASP.Models;
using TennisTableASP.ViewModels;
using System.Text.RegularExpressions;
using Rotativa;
using Rotativa.Options;

namespace TennisTableASP.Controllers
{
    public class MatchsController : Controller
    {
        private readonly Context _db = new Context();
        // GET: Clubs
        public ActionResult Index()
        {
            return View(GetMatchsList());
        }

        public ActionResult Details(int id)
        {
            MatchsViewModel MatchVm = new MatchsViewModel()
            {
                Matchs = new Matchs(),
                ListeRencontres = new List<Rencontres>()
            };
            MatchVm.Matchs = _db.Matchs.Include(m => m.Serie).Include(m => m.ClubVe).Include(m => m.ClubVr).Include(m => m.JVr1).Include(m => m.JVr2).Include(m => m.JVr3).Include(m => m.JVr4).Include(m => m.JVe1).Include(m => m.JVe2).Include(m => m.JVe3).Include(m => m.JVe4).FirstOrDefault(m => m.MatchId == id);
            int srList = _db.SchemasRencontres.Count(t => t.Type == MatchVm.Matchs.Serie.Type);
            for (int cpt = 1; cpt <= srList; cpt++)
            {
                SchemasRencontres sr = _db.SchemasRencontres.Where(s => s.Type == MatchVm.Matchs.Serie.Type).FirstOrDefault(s => s.Ordre == cpt);
                Rencontres rc = _db.Rencontres.Where(o => o.Sr.SrId == sr.SrId).FirstOrDefault(r => r.Match.MatchId == MatchVm.Matchs.MatchId);
                if (rc != null)
                {
                    MatchVm.ListeRencontres.Add(rc);
                }
            }
            return View(MatchVm);
        }
        // GET: Clubs/Create
        public ActionResult Create()
        {
            MatchsViewModel matchVm = new MatchsViewModel()
            {
                Matchs = new Matchs(),
                SeriesVm = new SeriesViewModel(),
                ClubsVeVm = new ClubsViewModel(),
                ClubsVrVm = new ClubsViewModel(),
                CapitaineVr = new JoueursViewModel(),
                CapitaineVe = new JoueursViewModel(),
                Joueur1Ve = new JoueursViewModel(),
                Joueur2Ve = new JoueursViewModel(),
                Joueur3Ve = new JoueursViewModel(),
                Joueur4Ve = new JoueursViewModel(),
                Joueur1Vr = new JoueursViewModel(),
                Joueur2Vr = new JoueursViewModel(),
                Joueur3Vr = new JoueursViewModel(),
                Joueur4Vr = new JoueursViewModel()
            };
            return View(matchVm);
        }
        // POST: Clubs/Create
        [HttpPost]
        public ActionResult Create(MatchsViewModel mVm)
        {
                mVm.Matchs.SerieId = mVm.SeriesVm.SerieChoisi;
                mVm.Matchs.ClubVisite = mVm.ClubsVeVm.ClubChoisi;
                mVm.Matchs.ClubVisiteur = mVm.ClubsVrVm.ClubChoisi;
                mVm.Matchs.CapitaineVisite = mVm.CapitaineVe.JoueurChoisi;
                mVm.Matchs.CapitaineVisiteur = mVm.CapitaineVr.JoueurChoisi;
                mVm.Matchs.J1Visite = mVm.Joueur1Ve.JoueurChoisi;
                mVm.Matchs.J2Visite = mVm.Joueur2Ve.JoueurChoisi;
                mVm.Matchs.J3Visite = mVm.Joueur3Ve.JoueurChoisi;
                mVm.Matchs.J4Visite = mVm.Joueur4Ve.JoueurChoisi;
                mVm.Matchs.J1Visiteur = mVm.Joueur1Vr.JoueurChoisi;
                mVm.Matchs.J2Visiteur = mVm.Joueur2Vr.JoueurChoisi;
                mVm.Matchs.J3Visiteur = mVm.Joueur3Vr.JoueurChoisi;
                mVm.Matchs.J4Visiteur = mVm.Joueur4Vr.JoueurChoisi;
                _db.Matchs.Add(mVm.Matchs);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
        // GET: Clubs/Edit/5
        public ActionResult Edit(int id)
        {
            MatchsViewModel MatchVm = new MatchsViewModel()
            {
                Matchs = new Matchs(),
                SeriesVm = new SeriesViewModel(),
                ClubsVeVm = new ClubsViewModel(),
                ClubsVrVm = new ClubsViewModel(),
                CapitaineVr = new JoueursViewModel(),
                CapitaineVe = new JoueursViewModel(),
                Joueur1Ve = new JoueursViewModel(),
                Joueur2Ve = new JoueursViewModel(),
                Joueur3Ve = new JoueursViewModel(),
                Joueur4Ve = new JoueursViewModel(),
                Joueur1Vr = new JoueursViewModel(),
                Joueur2Vr = new JoueursViewModel(),
                Joueur3Vr = new JoueursViewModel(),
                Joueur4Vr = new JoueursViewModel(),
                ListeRencontres = new List<Rencontres>()
            };
            MatchVm.Matchs =_db.Matchs.Include(m => m.Serie).Include(m => m.ClubVe).Include(m => m.ClubVr).Include(m => m.JVr1).Include(m => m.JVr2).Include(m => m.JVr3).Include(m => m.JVr4).Include(m => m.JVe1).Include(m => m.JVe2).Include(m => m.JVe3).Include(m => m.JVe4).FirstOrDefault(m => m.MatchId == id);
            int srList = _db.SchemasRencontres.Count(t => t.Type == MatchVm.Matchs.Serie.Type);
            MatchVm.SeriesVm.SerieChoisi = MatchVm.Matchs.Serie.SerieId;
            MatchVm.ClubsVeVm.ClubChoisi = MatchVm.Matchs.ClubVisite;
            MatchVm.ClubsVrVm.ClubChoisi = MatchVm.Matchs.ClubVisiteur;
            if (MatchVm.Matchs.CapitaineVisite != null) MatchVm.CapitaineVe.JoueurChoisi = MatchVm.Matchs.CapitaineVisite.Value;
            if (MatchVm.Matchs.CapitaineVisiteur != null) MatchVm.CapitaineVr.JoueurChoisi = MatchVm.Matchs.CapitaineVisiteur.Value;
            if (MatchVm.Matchs.J1Visite != null) MatchVm.Joueur1Ve.JoueurChoisi = MatchVm.Matchs.J1Visite.Value;
            if (MatchVm.Matchs.J2Visite != null) MatchVm.Joueur2Ve.JoueurChoisi = MatchVm.Matchs.J2Visite.Value;
            if (MatchVm.Matchs.J3Visite != null) MatchVm.Joueur3Ve.JoueurChoisi = MatchVm.Matchs.J3Visite.Value;
            if (MatchVm.Matchs.J4Visite != null) MatchVm.Joueur4Ve.JoueurChoisi = MatchVm.Matchs.J4Visite.Value;
            if (MatchVm.Matchs.J1Visiteur != null) MatchVm.Joueur1Vr.JoueurChoisi = MatchVm.Matchs.J1Visiteur.Value;
            if (MatchVm.Matchs.J2Visiteur != null) MatchVm.Joueur2Vr.JoueurChoisi = MatchVm.Matchs.J2Visiteur.Value;
            if (MatchVm.Matchs.J3Visiteur != null) MatchVm.Joueur3Vr.JoueurChoisi = MatchVm.Matchs.J3Visiteur.Value;
            if (MatchVm.Matchs.J4Visiteur != null) MatchVm.Joueur4Vr.JoueurChoisi = MatchVm.Matchs.J4Visiteur.Value;
            for (int cpt = 1;cpt <= srList;cpt++)
            {
                SchemasRencontres sr = _db.SchemasRencontres.Where(s => s.Type == MatchVm.Matchs.Serie.Type).FirstOrDefault(s => s.Ordre == cpt);
                Rencontres rc = _db.Rencontres.Where(o => o.Sr.SrId == sr.SrId).FirstOrDefault(r => r.Match.MatchId == MatchVm.Matchs.MatchId);
                if (rc != null)
                {
                    MatchVm.ListeRencontres.Add(rc);
                }
                else
                {
                    MatchVm.ListeRencontres.Add(new Rencontres()
                    {
                        MatchId = id,
                        Sr = sr,
                        SrId = sr.SrId
                    });
                    _db.Rencontres.Add(MatchVm.ListeRencontres[cpt-1]);
                    _db.SaveChanges();
                } 
            }
            return View(MatchVm);
        }
        // POST: Clubs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MatchsViewModel mVm)
        {
            try
            {
                Matchs matchUpdate = _db.Matchs.Find(id);
                if (matchUpdate != null)
                {
                    int srList = _db.SchemasRencontres.Count(t => t.Type == matchUpdate.Serie.Type);
                for (int cpt = 1; cpt <= srList; cpt++)
                { 
                    Rencontres rc = _db.Rencontres.Where(o => o.Sr.Ordre == cpt).FirstOrDefault(r => r.Match.MatchId == id);
                        rc.Score = String.Empty;
                    if (rc != null)
                    {
                        for (int cpt2 = 0; cpt2 < 10; cpt2++)
                        {

                            if (rc != null)
                            {
                                if (cpt2 % 2 == 0)
                                {
                                    rc.Score = rc.Score + Request.Form["Set" + cpt + cpt2] + "-";
                                }
                                else
                                {
                                    rc.Score = rc.Score + Request.Form["Set" + cpt + cpt2] + ";";
                                }
                            }
                        }
                    }
                    _db.SaveChanges();

                }
                    matchUpdate.SerieId = mVm.SeriesVm.SerieChoisi;
                    matchUpdate.ClubVisite = mVm.ClubsVeVm.ClubChoisi;
                    matchUpdate.ClubVisiteur = mVm.ClubsVrVm.ClubChoisi;
                    matchUpdate.CapitaineVisite = mVm.CapitaineVe.JoueurChoisi;
                    matchUpdate.CapitaineVisiteur = mVm.CapitaineVr.JoueurChoisi;
                    matchUpdate.J1Visite = mVm.Joueur1Ve.JoueurChoisi;
                    matchUpdate.J2Visite = mVm.Joueur2Ve.JoueurChoisi;
                    matchUpdate.J3Visite = mVm.Joueur3Ve.JoueurChoisi;
                    matchUpdate.J4Visite = mVm.Joueur4Ve.JoueurChoisi;
                    matchUpdate.J1Visiteur = mVm.Joueur1Vr.JoueurChoisi;
                    matchUpdate.J2Visiteur = mVm.Joueur2Vr.JoueurChoisi;
                    matchUpdate.J3Visiteur = mVm.Joueur3Vr.JoueurChoisi;
                    matchUpdate.J4Visiteur = mVm.Joueur4Vr.JoueurChoisi;
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
                return View(mVm);
            }
        }
        public ActionResult EditList()
        {
            MatchsViewModel matchsVm = new MatchsViewModel();
            return View(matchsVm);

        }
        public ActionResult ListEdit(MatchsViewModel vm)
        {
            return RedirectToAction("Edit", new { id = vm.MatchChoisi });
        }
        // GET: Clubs/Delete/5
        public ActionResult Delete(int id)
        {
            Matchs matchRemove = _db.Matchs.Find(id);
            return View(matchRemove);
        }
        // POST: Clubs/Delete/5
        [HttpPost]
        public ActionResult Delete(Matchs m,int id)
        {
            try
            {
                Matchs matchRemove = _db.Matchs.Find(id);
                if (matchRemove != null)
                {
                    _db.Matchs.Remove(matchRemove);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View(m);
            }
        }

        public ActionResult Impression(int id)
        {
            MatchsViewModel MatchVm = new MatchsViewModel()
            {
                Matchs = new Matchs(),
                ListeRencontres = new List<Rencontres>()
            };
            MatchVm.Matchs = _db.Matchs.Include(m => m.Serie).Include(m => m.ClubVe).Include(m => m.ClubVr).Include(m => m.JVr1).Include(m => m.JVr2).Include(m => m.JVr3).Include(m => m.JVr4).Include(m => m.JVe1).Include(m => m.JVe2).Include(m => m.JVe3).Include(m => m.JVe4).FirstOrDefault(m => m.MatchId == id);
            int srList = _db.SchemasRencontres.Count(t => t.Type == MatchVm.Matchs.Serie.Type);
            for (int cpt = 1; cpt <= srList; cpt++)
            {
                SchemasRencontres sr = _db.SchemasRencontres.Where(s => s.Type == MatchVm.Matchs.Serie.Type).FirstOrDefault(s => s.Ordre == cpt);
                Rencontres rc = _db.Rencontres.Where(o => o.Sr.SrId == sr.SrId).FirstOrDefault(r => r.Match.MatchId == MatchVm.Matchs.MatchId);
                if (rc != null)
                {
                    MatchVm.ListeRencontres.Add(rc);
                }
            }
            return new ViewAsPdf(MatchVm)
            {
                FileName = "Match" + MatchVm.Matchs.NumMatch +".pdf",
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
            };
        }

        public ActionResult DeleteList()
        {
            MatchsViewModel matchsVm = new MatchsViewModel();
            return View(matchsVm);

        }

        public ActionResult ListDelete(MatchsViewModel vm)
        {
            return RedirectToAction("Delete", new { id = vm.MatchChoisi });
        }

        private IQueryable<Matchs> GetMatchsList()
        {
            return _db.Matchs.Include(m => m.Serie).Include(m => m.ClubVe).Include(m => m.ClubVr).Include(m => m.JVr1).Include(m => m.JVr2).Include(m => m.JVr3).Include(m => m.JVr4).Include(m => m.JVe1).Include(m => m.JVe2).Include(m => m.JVe3).Include(m => m.JVe4);
        }
    }
}
