using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Models
{
    public class Tool_vm 
    {
        public int idTool { get; set;}
        public string Tag { get; set;}
        public string idUser { get; set; }
        public int IdType { get; set; }
        public string Active { get; set; }
        public string InsDateTime { get; set; }
        public string UpdDateTime { get; set; }
        public List<Property_vm> Properties { get; set; }
    }
}