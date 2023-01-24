using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        Model2Container db = new Model2Container();

        public ActionResult Index()
        {
            return View(db.KitaplarSet.ToList());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Yeni(Kitaplar ekle)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    db.KitaplarSet.Add(ekle);
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
                return View(db.KitaplarSet.Where(x => x.KitaplarId == id).FirstOrDefault());
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
                return View(db.KitaplarSet.Where(x => x.KitaplarId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Sil(int id,Kitaplar sil)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    sil = db.KitaplarSet.Where(x => x.KitaplarId == id).FirstOrDefault();
                    db.KitaplarSet.Remove(sil);
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
