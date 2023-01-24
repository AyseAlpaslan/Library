using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library.Models;
using Microsoft.SqlServer.Server;

namespace Library.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (Model2Container db = new Model2Container())
            {
                var result = db.AdminSet.Where(x => x.UserId == user.Username && x.Password1 == user.Password1);
                if (result.Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    //Session["userId]=user.Username;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["msg"] = "hatalı";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return View("Login");
        }

        [HttpGet]
        public ActionResult Yeni()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Yeni(Admin ekle)
        {
            try
            {
                using (Model2Container db = new Model2Container())
                {
                    db.AdminSet.Add(ekle);
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