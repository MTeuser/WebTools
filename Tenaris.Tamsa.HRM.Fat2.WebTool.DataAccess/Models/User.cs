using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess.Models
{
    public partial class User
    {
        #region Primitive Properties

        
        public global::System.Int32 idUser
        {
            get
            {
                return _idUser;
            }
            set
            {
                if (_idUser != value)
                {
                    
                    _idUser = value;
                 
                }
            }
        }
        private global::System.Int32 _idUser;
        public global::System.String Identification
        {
            get
            {
                return _Identification;
            }
            set
            {
               
                _Identification = value;
                
            }
        }
        private global::System.String _Identification;
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                
                _Password = value;
                
            }
        }
        private global::System.String _Password;
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
               
                _LastName = value;
                
            }
        }
        private global::System.String _LastName;
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                
                _FirstName = value;
                
            }
        }
        private global::System.String _FirstName;
        public global::System.Byte[] Picture
        {
            get
            {
                return _Picture;
            }
            set
            {
               
                _Picture = value;
               
            }
        }
        private global::System.Byte[] _Picture;
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
               
                _Email = value;
                
            }
        }
        private global::System.String _Email;
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

        #endregion
    }
}
