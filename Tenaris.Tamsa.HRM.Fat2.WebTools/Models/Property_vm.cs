using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Models
{
    public class Property_vm 
    {
        //idProperty, IdCatalog, IdDatatype, name
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

        public global::System.Int32 IdType
        {
            get
            {
                return _IdType;
            }
            set
            {

                _IdType = value;

            }
        }
        private global::System.Int32 _IdType;

        public global::System.Int32 IdDatatype
        {
            get
            {
                return _IdDatatype;
            }
            set
            {

                _IdDatatype = value;

            }
        }
        private global::System.Int32 _IdDatatype;

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

        public global::System.Int32 ViewUI
        {
            get
            {
                return _ViewUI;
            }
            set
            {

                _ViewUI = value;

            }
        }
        private global::System.Int32 _ViewUI;

        public global::System.String LabelUI
        {
            get
            {
                return _LabelUI;
            }
            set
            {

                _LabelUI = value;

            }
        }
        private global::System.String _LabelUI;

        public global::System.String TypeName
        {
            get
            {
                return _TypeName;
            }
            set
            {

                _TypeName = value;

            }
        }
        private global::System.String _TypeName;
    }
}