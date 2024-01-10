using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using tıbbitakipsistemi.Models;

namespace tıbbitakipsistemi.Controllers
{
    public class IlaclarController : Controller
    {
        // GET: Ilaclar

        TıbbiTakipSistemiEntities db = new TıbbiTakipSistemiEntities();
        [Authorize]
        public ActionResult Index(string ara)
        {

            var list = db.Ilac.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.Ilac1.Contains(ara)||x.IlacDozu.Contains(ara)).ToList();
            }


            return View(list);
        }
        public ActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Ilac data)
        {

            db.Ilac.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Sil(int id)
        {
            var ilac = db.Ilac.Where(x => x.ID==id).FirstOrDefault();
            db.Ilac.Remove(ilac);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {

            var guncelle = db.Ilac.Where(x => x.ID ==id).FirstOrDefault();


            return View(guncelle);


        }
        [HttpPost]
        public ActionResult Guncelle(Ilac model)
        {

            var data = db.Ilac.Find(model.ID);
            data.ID=model.ID;
            data.KullaniciId=model.KullaniciId;
            data.Ilac1=model.Ilac1;
            data.IlacDozu=model.IlacDozu;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}