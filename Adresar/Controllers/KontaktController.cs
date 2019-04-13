using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Adresar.Models;

namespace Adresar.Controllers
{
    public class KontaktController : Controller
    {
        //SPOJ NA BAZU: pristup modelu putem entityframeworka omogućen korištenjem instance klase ApplicationDbContext
        //globalna varijabla na nivou klase jer se koristi u više metoda kontrolera
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Kontakt
        public ActionResult Index()
        {
            List<Kontakt> aktivniKontakti = (from k in _db.Kontakti
                                             where k.Aktivan
                                             select k).ToList();
            return View(aktivniKontakti);
        }

        // GET: Kontakt/Create  /prazan je jer samo vraća formu
        public ActionResult Create()
        {
            return View();
        }

        //POST: Kontakt/Create 
        [HttpPost]
        public ActionResult Create(Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _db.Kontakti.Add(kontakt);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kontakt);
        }

        // GET: Kontakt/Details/5  
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakt kontakt = _db.Kontakti.Find(id);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        //GET: Kontakt/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakt kontakt = _db.Kontakti.Find(id);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        //POST: Kontakt/Edit/5
        [HttpPost]
        public ActionResult Edit(Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(kontakt).State=EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kontakt);
        }

        //GET: Kontakt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakt kontakt = _db.Kontakti.Find(id);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        //POST: Kontakt/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Kontakt kontakt = _db.Kontakti.Find(id);
            _db.Kontakti.Remove(kontakt);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}