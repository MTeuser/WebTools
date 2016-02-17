using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public partial class Tool_Tool
    {
        public int idTool { get; set; }
        public string Tag { get; set; }
        public int idSuplier { get; set; }
        public int IdType { get; set; }
        public int idUser { get; set; }
        public string Active { get; set; }
        public DateTimeOffset InsDateTime { get; set; }
        public DateTimeOffset UpdDateTime { get; set; }
        public string Value { get; set; }
        public int ViewUI { get; set; }        
        public string idProperty { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
    }
}
