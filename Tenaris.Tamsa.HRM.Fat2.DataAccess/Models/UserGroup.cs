using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public partial class UserGroup
    {
        #region Primitive Properties
        public global::System.Int32 idUserGroup
        {
            get
            {
                return _idUserGroup;
            }
            set
            {
                if (_idUserGroup != value)
                {
                   
                    _idUserGroup = value;
                   
                }
            }
        }
        private global::System.Int32 _idUserGroup;
        public global::System.Int32 idUser
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
        private global::System.Int32 _idUser;
        public global::System.Int32 idGroup
        {
            get
            {
                return _idGroup;
            }
            set
            {
                
                _idGroup =value;
              
            }
        }
        private global::System.Int32 _idGroup;
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
        public Nullable<global::System.DateTimeOffset> ExpirationDateTime
        {
            get
            {
                return _ExpirationDateTime;
            }
            set
            {
            
                _ExpirationDateTime = value;
                
            }
        }
        private Nullable<global::System.DateTimeOffset> _ExpirationDateTime;
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

        #endregion
    }
}
