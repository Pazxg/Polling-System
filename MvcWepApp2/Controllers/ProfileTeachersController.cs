using MvcWepApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWepApp2.Controllers
{
    public class ProfileTeachersController : Controller
    {
        // GET: ProfileEducator
        public ActionResult Index(int Id = 0)
        {
            if (Id != 0)
            {
                Egitmen egitmen = new Egitmen();
                egitmen.Id = Id;

                ProfileTeachersDTO dto = new ProfileTeachersDTO();
                dto._Egitmen = egitmen.EgitmenGetirId();

                Sinif sinif = new Sinif();
                dto.Siniflar = sinif.ListeGetir();
                return View(dto);
            }

            else
            {
                return RedirectToAction("Index", "Teachers");


            }
        }

        [HttpPost]
        public ActionResult Duzenle(int sinifId, int Id)
        {

            Egitmen egitmen = new Egitmen();
            egitmen._Sinif = new Sinif { Id = sinifId };
            egitmen.Id = Id;
            egitmen.Duzenle();
            return RedirectToAction("Index", "Teachers");
        }
    }
}