using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;

namespace Stok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDatabaseEntities db = new MvcDatabaseEntities();
        public ActionResult Index(string p)
        {
            var musteriler = from d in db.Tbl_Musteriler select d;
            if(!string.IsNullOrEmpty(p))
            {
                musteriler = musteriler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(musteriler.ToList());
            //var musteriler = db.Tbl_Musteriler.ToList();
            //return View(musteriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Tbl_Musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.Tbl_Musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var musteri = db.Tbl_Musteriler.Find(id);
            db.Tbl_Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.Tbl_Musteriler.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(Tbl_Musteriler p1)
        {
            var musteri = db.Tbl_Musteriler.Find(p1.MusterId);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}