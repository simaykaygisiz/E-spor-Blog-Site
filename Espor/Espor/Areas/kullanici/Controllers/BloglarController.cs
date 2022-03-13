using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Espor.Models;

namespace Espor.Areas.kullanici.Controllers
{

    [Authorize]
    public class BloglarController : Controller
    {
        // GET: kullanici/Bloglar
        public ActionResult Index()
        {
            using (esporEntities db = new esporEntities())
            {
                var model = db.blog.OrderBy(x => x.queue).ToList();
                return View(model);
            }
        }

        public ActionResult AnaSayfaGetir(int ID)
        {
            using (esporEntities db = new esporEntities())
            {
                var getir = db.blog.Find(ID);
                return View("AnaSayfaGetir" , getir);
            }
        }

        public ActionResult AnaSayfaGuncelle(blog x)
        {
            using (esporEntities db = new esporEntities())
            {
                var gunc = db.blog.Find(x.ID);
                gunc.title = x.title;
                gunc.content = x.content;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(blog x)
        {
            using (esporEntities db = new esporEntities())
            {
                db.blog.Add(x);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult BlogSil(int ID)
        {
            using (esporEntities db = new esporEntities())
            {
                var sil = db.blog.Find(ID);
                db.blog.Remove(sil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}