using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Models
{
    public class TipViewModel
    {
        [Display(Name="Id Punta")]
        public int id { get; set; }

        [Display(Name = "Proveedor")]
        public int idSupplier { get; set; }

        [Display(Name = "Estado")]
        public string status { get; set; }

        [Display(Name =  "Diametro")]
        public double diameter  { get; set; }

        [Display(Name = "Matricula")]
        public string tag { get; set; }

    }
}