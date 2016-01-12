// -----------------------------------------------------------------------
// <copyright file="Tool_SupplierMetadata.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.AusV1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;

   
    public class Tool_SupplierMetadata
    {
        
       [Display(Name = "Id Proveedor")]
        public global::System.Int32 idSupplier;
       
        [Display(Name = "Codigo")]
        public global::System.String Code;
       
        [Display(Name = "Nombre")]
        public global::System.String Name;
       
        [Display(Name = "Activo")]
        public global::System.Boolean Active;
      
        [Display(Name = "Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name = "Fecha Actualizacion")]
        public global::System.DateTimeOffset UpdDateTime;
        
    }
}
