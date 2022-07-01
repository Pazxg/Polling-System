﻿using MvcWepApp2.CORE;
using MvcWepApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWepApp2.Controllers
{
    [SessionControl]
    public class TeacherController : Controller
    {
        
        // GET: Teacher
        public ActionResult Index()
        {
            Ogretmen ogretmen = new Ogretmen();
            OgretmenDTO ogretmenDTO = new OgretmenDTO();
            Sinif sinif = new Sinif();

            ogretmenDTO.Ogretmenler = ogretmen.ListeGetir();
            ogretmenDTO.Siniflar = sinif.ListeGetir();

            return View(ogretmenDTO);
        }

        [HttpPost]
        public ActionResult Ekle(string ogretmenAdi, string ogretmenSoyadi, string ogretmenCode, int sinifId)
        {
            Ogretmen ogretmen = new Ogretmen();
            ogretmen.Adi = ogretmenAdi;
            ogretmen.Soyadi = ogretmenSoyadi;
            ogretmen.Code = ogretmenCode;
            ogretmen._Sinif = new Sinif { Id = sinifId };



            if (ogretmen.Ekle())
            {
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                return RedirectToAction("Index", "Teacher");
            }
        }
        [HttpPost]
        public bool Sil(int Id)
        {
            Ogretmen ogretmen= new Ogretmen();
            ogretmen.Id = Id;
            return ogretmen.Sil();
        }
    }
}