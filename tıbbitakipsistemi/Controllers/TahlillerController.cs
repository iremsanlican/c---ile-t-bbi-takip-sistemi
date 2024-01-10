using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tıbbitakipsistemi.Models;

namespace tıbbitakipsistemi.Controllers
{
    public class TahlillerController : Controller
    {
        // GET: Tahliller
        TıbbiTakipSistemiEntities db = new TıbbiTakipSistemiEntities();
        [Authorize]


        public ActionResult Index(string ara)
        {

            var list = db.Tahlil.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.TahlilBilgisi.Contains(ara) ).ToList();
            }


            return View(list);
        }

        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Tahlil data)
        {

            db.Tahlil.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Sil(int id)
        {
            var tahlil= db.Tahlil.Where(x => x.ID==id).FirstOrDefault();
            db.Tahlil.Remove(tahlil);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.Tahlil.Where(x => x.ID ==id).FirstOrDefault();
              return View(guncelle);

        }
        [HttpPost]
        public ActionResult Guncelle(Tahlil model)
        {
          
                var data = db.Tahlil.Find(model.ID);
                data.ID=model.ID;
                data.KullaniciId=model.KullaniciId;
                data.Tarih=model.Tarih;
                data.TahlilBilgisi=model.TahlilBilgisi;
                data.TahlilSonuc=model.TahlilSonuc;
                db.SaveChanges();
                return RedirectToAction("Index");

            
          
        }
        }
}