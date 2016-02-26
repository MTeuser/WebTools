using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public partial class Tool_Type
    {
        #region Primitive Properties

      
        public global::System.Int32 idType
        {
            get
            {
                return _idType;
            }
            set
            {
                if (_idType != value)
                {
                  
                    _idType =value;
                   
                }
            }
        }
        private global::System.Int32 _idType;
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
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                
                _Description = value;
                
            }
        }
        private global::System.String _Description;
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

        #endregion
    }
}
