using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;
using System.Data.Entity;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        private WebShopEntities db = new WebShopEntities(); //povezivanje sa bazom db (naziv dolazi iz Web.configa)
        public static List<Proizvodi> lstProizvodi = new List<Proizvodi>();

        // GET: Cart
        public ActionResult Index()
        {
            if (Session["Cart"] != null)
            {
                lstProizvodi = Session["Cart"] as List<Proizvodi>;
            }

            return View(lstProizvodi);
        }

        public ActionResult AddToCart(int id)
        {
            Proizvodi proizvodi = db.Proizvodis.Find(id);//dio entity frameworka na koji mapira
            int prodet = db.Proizvodis.Find(id).NarudzbeDetaljis.Count;
            Session["prodet"] = prodet;
            lstProizvodi.Add(proizvodi);
            Session["Cart"] = lstProizvodi;

            if (proizvodi == null)
            {
                return HttpNotFound("GREŠKA: proizvod nije pronađen!");
            }
            var proi = db.Proizvodis.Include(p => p.MjereProizvoda);

            return RedirectToAction(actionName: "Index", controllerName: "WebShop", routeValues: proi.ToList());
        }

        public ActionResult RemoveFromCart(int index)
        {
            lstProizvodi = Session["Cart"] as List<Proizvodi>;
            lstProizvodi.RemoveAt(index);
            Session["Cart"] = lstProizvodi;
            return View("Index", lstProizvodi);
        }
    }
}