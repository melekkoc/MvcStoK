using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stok.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace Stok.Controllers
{
    public class CategoriController : Controller
    {

        // GET: Categori
        MvcDatabaseEntities db = new MvcDatabaseEntities();
        public ActionResult Index( int sayfa=1)
        {
            //var degerler = db.tbl_Kategori.ToList();
            var degerler = db.tbl_Kategori.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(tbl_Kategori p1)
        {
            if(!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.tbl_Kategori.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult Sil(int id)
        {
            var kategori = db.tbl_Kategori.Find(id);
            db.tbl_Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.tbl_Kategori.Find(id);
            return View("KategoriGetir",ktg);
        }
        
        public ActionResult Guncelle(tbl_Kategori p1)
        {
            var ktg = db.tbl_Kategori.Find(p1.kategoriId);
            ktg.kategoriAd = p1.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
 
    }

}