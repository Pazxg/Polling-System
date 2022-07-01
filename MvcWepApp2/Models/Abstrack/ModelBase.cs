using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWepApp2.Models.Abstrack
{
    public abstract class ModelBase
    {
        public ModelBase()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}