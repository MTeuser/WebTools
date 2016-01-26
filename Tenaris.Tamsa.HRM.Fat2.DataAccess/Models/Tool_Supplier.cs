using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public partial class Tool_Supplier
    {
     
        public global::System.Int32 idSupplier
        {
            get
            {
                return _idSupplier;
            }
            set
            {
                if (_idSupplier != value)
                {
                  
                    _idSupplier = value;
                   
                }
            }
        }
        private global::System.Int32 _idSupplier;
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
             
                _Code = value;
               
            }
        }
        private global::System.String _Code;
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
              
                _Name = value;
               
            }
        }
        private global::System.String _Name;
        public global::System.Boolean Active
        {
            get
            {
                return _Active;
            }
            set
            {
                
                _Active = value;
               
            }
        }
        private global::System.Boolean _Active;
        public global::System.DateTimeOffset InsDateTime
        {
            get
            {
                return _InsDateTime;
            }
            set
            {
               
                _InsDateTime = value;
               
            }
        }
        private global::System.DateTimeOffset _InsDateTime;
        public global::System.DateTimeOffset UpdDateTime
        {
            get
            {
                return _UpdDateTime;
            }
            set
            {
                
                _UpdDateTime = value;
               
            }
        }
        private global::System.DateTimeOffset _UpdDateTime;
    }
}
