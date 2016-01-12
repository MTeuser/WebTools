using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess.Models
{
    public partial class HeatHistory
    {
       
        public global::System.Int32 idHeatHistory
        {
            get
            {
                return _idHeatHistory;
            }
            set
            {
                if (_idHeatHistory != value)
                {                 
                    _idHeatHistory = value;
                   
                }
            }
        }
        private global::System.Int32 _idHeatHistory;
        public global::System.String SteelCode
        {
            get
            {
                return _SteelCode;
            }
            set
            {              
                _SteelCode = value;               
            }
        }
        private global::System.String _SteelCode;
        public global::System.Int32 HeatNumber
        {
            get
            {
                return _HeatNumber;
            }
            set
            {               
                _HeatNumber = value;
            }
        }
        private global::System.Int32 _HeatNumber;
        public global::System.String StencilColor
        {
            get
            {
                return _StencilColor;
            }
            set
            {              
                _StencilColor = value;
            }
        }
        private global::System.String _StencilColor;
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

    }
}
