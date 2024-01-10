using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tıbbitakipsistemi.Models;

namespace tıbbitakipsistemi.Controllers
{
    public class AlerjiController : Controller
    {
        // GET: Alerji
        TıbbiTakipSistemiEntities db = new TıbbiTakipSistemiEntities();
        [Authorize]


        public ActionResult Index(string ara)
        {

         var list = db.Alerji.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.Alerji1.Contains(ara)).ToList();
            }


          return View(list);
    }
        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Alerji data)
        {

            db.Alerji.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var alerji = db.Alerji.Where(x => x.ID==id).FirstOrDefault();
            db.Alerji.Remove(alerji);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {


            var guncelle = db.Alerji.Where(x => x.ID ==id).FirstOrDefault();


            return View(guncelle);


        }
        [HttpPost]
        public ActionResult Guncelle(Alerji model)
        {

            var data = db.Alerji.Find(model.ID);
            data.ID=model.ID;
            data.KullaniciId=model.KullaniciId;
            data.Alerji1=model.Alerji1;
          
            db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}



