using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public partial class Tool_ToolDetail
    {

       
        public global::System.Int32 idToolDetail
        {
            get
            {
                return _idToolDetail;
            }
            set
            {
                if (_idToolDetail != value)
                {

                    _idToolDetail = value;
                    
                }
            }
        }
        private global::System.Int32 _idToolDetail;
        public Nullable<global::System.Int32> idProperty
        {
            get
            {
                return _idProperty;
            }
            set
            {
               
                _idProperty =value;
                
            }
        }
        private Nullable<global::System.Int32> _idProperty;
        public Nullable<global::System.Int32> idTool
        {
            get
            {
                return _idTool;
            }
            set
            {
               
                _idTool = value;
                
            }
        }
        private Nullable<global::System.Int32> _idTool;
    }
}
