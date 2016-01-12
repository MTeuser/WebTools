using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess.Models
{
    public partial class Tool_Property
    {
        
        public global::System.Int32 idProperty
        {
            get
            {
                return _idProperty;
            }
            set
            {
                if (_idProperty != value)
                {
                   
                    _idProperty = value;
                   
                }
            }
        }
        private global::System.Int32 _idProperty;
        public Nullable<global::System.Int32> dataType
        {
            get
            {
                return _dataType;
            }
            set
            {
              
                _dataType = value;
              
            }
        }
        private Nullable<global::System.Int32> _dataType;
        public global::System.String Value
        {
            get
            {
                return _Value;
            }
            set
            {
              
                _Value = value;
               
            }
        }
        private global::System.String _Value;
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
              
                _name = value;
               
            }
        }
        private global::System.String _name;
    }
}
