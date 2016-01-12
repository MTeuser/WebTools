using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess.Models
{
    public partial class GroupPolicy
    {
       
        public global::System.Int32 idGroupPolicy
        {
            get
            {
                return _idGroupPolicy;
            }
            set
            {
                if (_idGroupPolicy != value)
                {                  
                    _idGroupPolicy = value;
                }
            }
        }
        private global::System.Int32 _idGroupPolicy;
        public global::System.Int32 idGroup
        {
            get
            {
                return _idGroup;
            }
            set
            {
               
                _idGroup = value;
            }
        }
        private global::System.Int32 _idGroup;
        public global::System.Int32 idApplicationCommand
        {
            get
            {
                return _idApplicationCommand;
            }
            set
            {
                _idApplicationCommand = value;
            }
        }
        private global::System.Int32 _idApplicationCommand;
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
