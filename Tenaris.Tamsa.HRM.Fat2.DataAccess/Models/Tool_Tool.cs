using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public partial class Tool_Tool
    {
       
        public global::System.Int32 idTool
        {
            get
            {
                return _idTool;
            }
            set
            {
                if (_idTool != value)
                {
                 
                    _idTool = value;
                   
                }
            }
        }
        private global::System.Int32 _idTool;
        public global::System.String Tag
        {
            get
            {
                return _Tag;
            }
            set
            {
              
                _Tag = value;
              
            }
        }
        private global::System.String _Tag;
        public Nullable<global::System.Int32> idSuplier
        {
            get
            {
                return _idSuplier;
            }
            set
            {
              
                _idSuplier = value;
               
            }
        }
        private Nullable<global::System.Int32> _idSuplier;
        public Nullable<global::System.Int32> idType
        {
            get
            {
                return _idType;
            }
            set
            {
               
                _idType = value;
               
            }
        }
        private Nullable<global::System.Int32> _idType;
        public Nullable<global::System.Int32> idUser
        {
            get
            {
                return _idUser;
            }
            set
            {
                
                _idUser = value;
               
            }
        }
        private Nullable<global::System.Int32> _idUser;
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
