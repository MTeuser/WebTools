using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public class Tool_Catalog
    {
        private global::System.Int32 _IdCatalog;

        public global::System.Int32 IdCatalog
        {
            get { return _IdCatalog; }
            set { _IdCatalog = value; }
        }
        private global::System.Int32 _IdType;

        public global::System.Int32 IdType
        {
            get { return _IdType; }
            set { _IdType = value; }
        }
        private global::System.Boolean _Active;

        public global::System.Boolean Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        private global::System.DateTimeOffset _InsDateTime;

        public global::System.DateTimeOffset InsDateTime
        {
            get { return _InsDateTime; }
            set { _InsDateTime = value; }
        }
        private global::System.DateTimeOffset _UpdDateTime;

        public global::System.DateTimeOffset UpdDateTime
        {
            get { return _UpdDateTime; }
            set { _UpdDateTime = value; }
        }
    }
}
