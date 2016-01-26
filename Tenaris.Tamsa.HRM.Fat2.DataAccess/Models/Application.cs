// -----------------------------------------------------------------------
// <copyright file="Applicacation.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Application
    {
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>      
        public global::System.Int32 idApplication
        {
            get
            {
                return _idApplication;
            }
            set
            {
                _idApplication = value;
            }
        }

        private global::System.Int32 _idApplication;        

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>       
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
      

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        
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

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>        
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
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>        
        public global::System.Boolean IsManager
        {
            get
            {
                return _IsManager;
            }
            set
            {                
                _IsManager = value;                
            }
        }
        private global::System.Boolean _IsManager;        

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>        
        public global::System.String FileName
        {
            get
            {
                return _FileName;
            }
            set
            {                
                _FileName = value;             
            }
        }
        private global::System.String _FileName;

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>        
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
        

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
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
       

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>       
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
