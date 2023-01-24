using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
namespace Library.Controllers
{
    public class ReaderController : Controller
    {
        // GET: Reader
        Model2Container db = new Model2Container();
        public ActionResult Index()
        {
            return View(db.OkurSet.ToList());
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Yeni(Okur ekle)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    db.OkurSet.Add(ekle);
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
                return View(db.OkurSet.Where(x => x.OkurId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Okur duzenle)
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
                return View(db.OkurSet.Where(x => x.OkurId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Sil(int id, Okur sil)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    sil = db.OkurSet.Where(x => x.OkurId == id).FirstOrDefault();
                    db.OkurSet.Remove(sil);
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