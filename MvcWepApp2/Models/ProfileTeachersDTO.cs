using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWepApp2.Models
{
    public class ProfileTeachersDTO
    {
        public Egitmen _Egitmen { get; set; }
        public List<Sinif> Siniflar { get; set; }
    }
}