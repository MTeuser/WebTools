using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Models
{
    public class ToolViewModel
    {
        [Display(Name="Id Punta")]
        public int id { get; set; }

        public int idType { get; set; }

        public List<Tool_Property> Properties { get; set; }
    }
}