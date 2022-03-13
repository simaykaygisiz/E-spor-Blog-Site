using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Espor.Models;

namespace Espor.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (esporEntities db = new esporEntities())
            {
                var model = db.blog.OrderBy(x => x.queue).ToList();
                return View(model);
            }

        }

        [Route("blog/{ID}")]
        public ActionResult BlogDetay(int ID)
        {
            using (esporEntities db = new esporEntities())
            {
                var model = db.blog.Where(x => x.ID == ID).FirstOrDefault();
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }

        [Route("hakkimizda")]
        public ActionResult Hakkimizda()
        {
            return View();
        }
        [Route("iletisim")]
        public ActionResult Iletisim()
        {
            return View();
        }
        
    }
}