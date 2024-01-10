using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tıbbitakipsistemi.Models;

namespace tıbbitakipsistemi.Controllers
{
    public class KullanıcıController : Controller
    {
        // GET: Kullanıcı
        TıbbiTakipSistemiEntities db = new TıbbiTakipSistemiEntities();
        [Authorize]
        public ActionResult Index()



        {

            var list = db.Kullanici.ToList();



            return View(list);
        }
    }
}