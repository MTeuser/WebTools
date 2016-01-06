// -----------------------------------------------------------------------
// <copyright file="ApplicationCommand.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class ApplicationCommand
    {
        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        
        
        public global::System.Int32 idApplicationCommand
        {
            get
            {
                return _idApplicationCommand;
            }
            set
            {
                if (_idApplicationCommand != value)
                {
                   
                    _idApplicationCommand = value;
                   
                }
            }
        }
        private global::System.Int32 _idApplicationCommand;
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
        
        
        public global::System.String Command
        {
            get
            {
                return _Command;
            }
            set
            {
               
                _Command = value;
               
            }
        }
        private global::System.String _Command;
      
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

        #endregion
    }
}
