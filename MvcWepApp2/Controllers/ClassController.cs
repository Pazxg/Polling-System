using MvcWepApp2.CORE;
using MvcWepApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWepApp2.Controllers
{
    [SessionControl]
    public class ClassController : Controller
    {
       

        // GET: Class
        public ActionResult Index()
        {
            //TODO : Session kontrolü eklenecek...
            Sinif sinif = new Sinif();
            return View(sinif.ListeGetir());
        }

        [HttpPost]
        public ActionResult Ekle(string sinifAdi, string sinifKodu)
        {
            Sinif sinif = new Sinif
            {
                Adi = sinifAdi,
                Kodu = sinifKodu
            };

            if (sinif.Ekle())
            {
                return RedirectToAction("Index", "Class");
            }
            else
            {
                return RedirectToAction("Index", "Class");
            }
        }

        [HttpPost]
        public void Sil(int Id)
        {
            Sinif sinif = new Sinif();
            sinif.Id = Id;
            sinif.Sil();

        }
    }
}