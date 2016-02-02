using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Models
{
    public class Catalog_vm
    {
        //Modelo Tool_Catalog
        private Int32 _IdCatalog;

        public Int32 IdCatalog
        {
            get { return _IdCatalog; }
            set { _IdCatalog = value; }
        }
        private Int32 _IdType;

        public Int32 IdType
        {
            get { return _IdType; }
            set { _IdType = value; }
        }
        private Boolean _Active;

        public Boolean Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        private DateTimeOffset _InsDateTime;

        public DateTimeOffset InsDateTime
        {
            get { return _InsDateTime; }
            set { _InsDateTime = value; }
        }
        private DateTimeOffset _UpdDateTime;

        public DateTimeOffset UpdDateTime
        {
            get { return _UpdDateTime; }
            set { _UpdDateTime = value; }
        }
      
        //Se añaden el modelo Tool_Type
        public String Code
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
        private String _Code;
        public String Name
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
        private String _Name;
        public String Description
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
        private String _Description;

    }
}