using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess.Models
{
    public partial class Group
    {
      
        public global::System.Int32 idGroup
        {
            get
            {
                return _idGroup;
            }
            set
            {
                if (_idGroup != value)
                {
                   
                    _idGroup = value;
                   
                }
            }
        }
        private global::System.Int32 _idGroup;
        public global::System.Int32 idZone
        {
            get
            {
                return _idZone;
            }
            set
            {
               
                _idZone = value;
            }
        }
        private global::System.Int32 _idZone;
        public global::System.String Code
        {
            get
            {
                return _Code;
            }
            set
            {
                
                _Code =value;
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
