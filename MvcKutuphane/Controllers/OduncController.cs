using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult OduncIade(int id)
        {
            var odunc = db.TBLHAREKET.Find(id);
            return View("OduncIade", odunc);
        }

        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrkt = db.TBLHAREKET.Find(p.ID);
            hrkt.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrkt.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}