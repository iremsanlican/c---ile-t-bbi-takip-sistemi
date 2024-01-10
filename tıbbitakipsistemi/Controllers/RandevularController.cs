using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tıbbitakipsistemi.Models;

namespace tıbbitakipsistemi.Controllers
{
    public class RandevularController : Controller
    {
        // GET: Randevular
        TıbbiTakipSistemiEntities db = new TıbbiTakipSistemiEntities();
        [Authorize]


        public ActionResult Index(string ara)
        {

            var list = db.Randevu.ToList();

            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.Hastane.Contains(ara) ||x.Bölüm.Contains(ara)).ToList();
            }


            return View(list);
        }

        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Randevu data)
        {

           db.Randevu.Add(data);
           db.SaveChanges();


            return RedirectToAction("Index");
        }
  
        public ActionResult Sil(int id)
        {
            var randevu = db.Randevu.Where(x => x.ID==id).FirstOrDefault();
            db.Randevu.Remove(randevu);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {


            var guncelle = db.Randevu.Where(x => x.ID ==id).FirstOrDefault();


            return View(guncelle);

        }

        [HttpPost]
        public ActionResult Guncelle(Randevu model)
        {

            var data = db.Randevu.Find(model.ID);
            data.ID=model.ID;
            data.KullaniciId=model.KullaniciId;
            data.Tarih=model.Tarih;
            data.Hastane=model.Hastane;
            data.Bölüm=model.Bölüm;
            db.SaveChanges();
            return RedirectToAction("Index");



        }


    }
}
   