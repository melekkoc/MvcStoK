using Stok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDatabaseEntities db = new MvcDatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tbl_Satis p)
        {
            db.tbl_Satis.Add(p);
            db.SaveChanges();
            return View("Index");

        }

    }
}