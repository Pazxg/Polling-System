using MvcWepApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWepApp2.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kullaniciAdi, string sifre)
        {

            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAdi = kullaniciAdi;
            kullanici.Sifre = sifre;

            if (kullanici.GirisYap())
            {
                Session["Kullanici"] = kullaniciAdi;
                Session["Yetki"] = "Yonetici";
                return RedirectToAction("Index","Dashboard");
            }

            return View();

        }
       
        public ActionResult TeacherLogin()
        {
            return View();
        }
        [HttpPost]

        public ActionResult TeacherLogin(string kullaniciAdi, string sifre)
        {

            Ogretmen ogretmen = new Ogretmen();
            ogretmen.Code = kullaniciAdi;
            ogretmen.Sifre = sifre;

            if (ogretmen.GirisYap())
            {
                Session["Kullanici"] = kullaniciAdi;
                Session["Yetki"] = "Ogretmen";
                return RedirectToAction("RollCall", "Dashboard");
            }

            return View();

        }
    }
}