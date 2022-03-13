using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Espor.Models;
using System.Web.Security;

namespace Espor.Areas.kullanici.Controllers
{
    public class LoginController : Controller
    {
        // GET: kullanici/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Alogin(admin adminFormu)
        {

            if (!ModelState.IsValid)
            {
                return View("index", adminFormu);
            }

            using (esporEntities db = new esporEntities())
            {
                var adminVarmi = db.admin.FirstOrDefault(x => x.username == adminFormu.username && x.password == adminFormu.password);

                if(adminVarmi != null)
                {
                    FormsAuthentication.SetAuthCookie(adminVarmi.username, false);

                    return RedirectToAction("/index", "bloglar");
                }

                ViewBag.Hata = "Kullanıcı adı veya şifre yanlış!";
                return View("index");
            }
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}