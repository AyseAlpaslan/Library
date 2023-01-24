using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class BorrowController : Controller
    {
        // GET: Borrow

        Model2Container db = new Model2Container();
     
        public ActionResult Index()
        {
            return View(db.OduncSet.ToList());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Yeni(Odunc ekle)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    db.OduncSet.Add(ekle);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            using (Model2Container db = new Model2Container())
            {
                return View(db.OduncSet.Where(x => x.OduncId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Kitaplar duzenle)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    db.Entry(duzenle).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult Sil(int id)
        {
            using (Model2Container db = new Model2Container())
            {
                return View(db.OduncSet.Where(x => x.OduncId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Sil(int id, Odunc sil)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    sil = db.OduncSet.Where(x => x.OduncId == id).FirstOrDefault();
                    db.OduncSet.Remove(sil);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
    }
}