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
    public class DashboardController : Controller
    {
       
        // GET: Dashboard
        public ActionResult Index()
        {
           return View();   
           
        }
        public ActionResult RollCall() {

            DersProgrami dersprogrami = new DersProgrami();

            dersprogrami.OgretmenKodu = Session["Kullanici"].ToString();

            return View(dersprogrami.ListeGetir());

        }
        [HttpPost]
        public JsonResult OgrenciListesiGetir(int SinifId)
        {
            Ogrenci ogrenci= new Ogrenci();
            ogrenci.SinifId = SinifId;
            return Json(ogrenci.OgrencileriGetirSinifId());
        }

    }
}