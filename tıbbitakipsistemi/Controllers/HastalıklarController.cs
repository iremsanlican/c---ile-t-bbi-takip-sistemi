using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Windows.Documents;
using tıbbitakipsistemi.Models;
using tıbbitakipsistemi.Controllers;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;


namespace tıbbitakipsistemi.Controllers
{
    [Authorize]
    public class HastalıklarController : Controller
    {
        // GET: Hastalıklar


        TıbbiTakipSistemiEntities db = new TıbbiTakipSistemiEntities();

        public ActionResult Index( string ara)
        {
           
         var list = db.Hastalik.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x =>x.Hastalik1.Contains(ara)).ToList();
            }



            return View(list);
  }
        public ActionResult Ekle()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Hastalik data)
        {

            db.Hastalik.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

            public ActionResult Sil(int id)
        {
            var hastalik = db.Hastalik.Where(x => x.ID==id).FirstOrDefault();
            db.Hastalik.Remove(hastalik);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {

            var guncelle = db.Hastalik.Where(x => x.ID ==id).FirstOrDefault();
         
               
                return View(guncelle);
            

        }
        [HttpPost]
        public ActionResult Guncelle(Hastalik model)
        {

            var data = db.Hastalik.Find(model.ID);
            data.ID=model.ID;
            data.KullaniciId=model.KullaniciId;
            data.Tarih=model.Tarih;
            data.Hastalik1=model.Hastalik1;
            db.SaveChanges();
            return RedirectToAction("Index");



        }


    }
}


