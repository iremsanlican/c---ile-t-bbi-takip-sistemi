using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using tıbbitakipsistemi.Models;

namespace tıbbitakipsistemi.Controllers
{
    public class AccountController : Controller
    {
        TıbbiTakipSistemiEntities db = new TıbbiTakipSistemiEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Kullanici k)
           {
            var bilgiler = db.Kullanici.FirstOrDefault(x => x.KullaniciAdi==k.KullaniciAdi&&x.Parola==k.Parola);
                 if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                    Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                    Session["Ad"] = bilgiler.Ad.ToString();
                    Session["Soyad"] = bilgiler.Soyad.ToString();
                   Session["ID"] = bilgiler.ID.ToString();
                return RedirectToAction("Index", "Home");
               }


                else

                {
                    ViewBag.hata="Bilgilerinizi kontrol ediniz";


                }
                return View();
            }


               public ActionResult Register()
           {
               return View();

           }

        [HttpPost]
         public ActionResult Register(Kullanici data)
         {

            db.Kullanici.Add(data);
             data.Equals(db.Kullanici);
             db.SaveChanges();
             return RedirectToAction("Login", "Account");


         }

       

    }

}

