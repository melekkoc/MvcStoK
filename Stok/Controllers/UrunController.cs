using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;

namespace Stok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDatabaseEntities db = new MvcDatabaseEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_Urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> degerler = (from i in db.tbl_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(tbl_Urunler p1)
        {
            var ktg = db.tbl_Kategori.Where(m => m.kategoriId == p1.tbl_Kategori.kategoriId).FirstOrDefault();
            p1.tbl_Kategori = ktg;

            db.tbl_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.tbl_Urunler.Find(id);
            db.tbl_Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.tbl_Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.tbl_Kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urun);
        }
        public ActionResult Guncelle(tbl_Urunler p)
        {
            var urun = db.tbl_Urunler.Find(p.UrunId);
            urun.UrunAdı = p.UrunAdı;
            urun.Marka = p.Marka;
            urun.Fiyat = p.Fiyat;
            urun.Stok = p.Stok;
            var ktg = db.tbl_Kategori.Where(m => m.kategoriId == p.tbl_Kategori.kategoriId).FirstOrDefault();
            urun.UrunKategori= ktg.kategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}