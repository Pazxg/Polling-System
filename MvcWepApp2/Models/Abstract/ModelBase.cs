using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWepApp2.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } 
        public ModelBase ()
        {
            CreatedDate= DateTime.Now;
        }
    }
}