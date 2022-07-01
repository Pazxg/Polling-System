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
    public class StudentController : Controller
    {
      
        // GET: Student
        public ActionResult Index()
        {
            //TODO : Session kontrolü eklenecek...
            Ogrenci ogrenci = new Ogrenci();
            Sinif sinif = new Sinif();
            OgrenciDTO ogrenciDTO = new OgrenciDTO();
            ogrenciDTO.Ogrenciler = ogrenci.OgrencileriGetir();
            ogrenciDTO.Siniflar = sinif.ListeGetir();
            return View(ogrenciDTO);
        }

        [HttpPost]
        public ActionResult Ekle(string ogrenciAdi, string ogrenciSoyad, string ogrenciNo, int sinifId)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Adi = ogrenciAdi;
            ogrenci.Soyad = ogrenciSoyad;
            ogrenci.No = ogrenciNo;
            ogrenci._Sinif = new Sinif { Id = sinifId };



            if (ogrenci.Ekle())
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
        }
        [HttpPost]
        public bool Sil(int Id)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Id = Id;
            return ogrenci.Sil();
        }
    }
}