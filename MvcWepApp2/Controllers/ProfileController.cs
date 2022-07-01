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
    public class ProfileController : Controller
    {
        //GET: Profile
        public ActionResult Index(int Id = 0)
        {
            if (Id != 0)
            {
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Id = Id;

                ProfileDTO dto = new ProfileDTO();
                dto._Ogrenci = ogrenci.OgrenciGetirId();

                Sinif sinif = new Sinif();
                dto.Siniflar = sinif.ListeGetir();


                return View(dto);
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }

        }
        [HttpPost]
        public ActionResult Duzenle(int sinifId, int Id)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci._Sinif = new Sinif { Id = sinifId };
            ogrenci.Id = Id;
            ogrenci.Duzenle();
            return RedirectToAction("Index", "Student");
        }

        // GET: Profile
        public ActionResult Teacher(int Id = 0)
        {
            if (Id != 0)
            {
                Ogretmen ogretmen = new Ogretmen();
                ogretmen.Id = Id;

                ProfileTeacherDTO dto = new ProfileTeacherDTO();
                dto.Ogretmen = ogretmen.OgretmenGetirId();

                Sinif sinif = new Sinif();
                dto.Siniflar = sinif.ListeGetir();


                return View(dto);
            }
            else
            {
                return RedirectToAction("Index", "Teacher");
            }

        }
        [HttpPost]
        public ActionResult OgretmenDuzenle(int sinifId, int Id)
        {
            Ogretmen ogretmen = new Ogretmen();
            ogretmen._Sinif = new Sinif { Id = sinifId };
            ogretmen.Id = Id;
            ogretmen.Duzenle();
            return RedirectToAction("Index", "Teacher");
        }

        public ActionResult classs()
        {

            return View();
        }
        public ActionResult Ekle(string dersAdi, DateTime dersBaslangic, DateTime dersBitis)
        {
            DersProgrami dersProgrami = new DersProgrami();
            dersProgrami.DersAdi = dersAdi;
            dersProgrami.Baslangic = dersBaslangic;
            dersProgrami.Bitis = dersBitis;




            if (dersProgrami.Ekle())
            {
                return RedirectToAction("Index", "Class");
            }
            else
            {
                return RedirectToAction("Index", "Class");
            }
        }
    }
}