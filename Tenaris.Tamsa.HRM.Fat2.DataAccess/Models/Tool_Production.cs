using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    public partial class Tool_Production
    {
       
        public global::System.Int32 idProduction
        {
            get
            {
                return _idProduction;
            }
            set
            {
                if (_idProduction != value)
                {                  
                    _idProduction = value;                   
                }
            }
        }
        private global::System.Int32 _idProduction;
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
        public Nullable<global::System.Double> weight
        {
            get
            {
                return _weight;
            }
            set
            {
               
                _weight = value;
                
            }
        }
        private Nullable<global::System.Double> _weight;
        public Nullable<global::System.Int32> pieces
        {
            get
            {
                return _pieces;
            }
            set
            {
               
                _pieces = value;
            }
        }
        private Nullable<global::System.Int32> _pieces;
        public global::System.Int32 idHeatHistory
        {
            get
            {
                return _idHeatHistory;
            }
            set
            {
                
                _idHeatHistory = value;
            }
        }
        private global::System.Int32 _idHeatHistory;
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
        partial void OnInsDateTimeChanging(global::System.DateTimeOffset value);
        partial void OnInsDateTimeChanged();

       
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
