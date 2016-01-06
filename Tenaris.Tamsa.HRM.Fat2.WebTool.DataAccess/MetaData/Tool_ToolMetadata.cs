// -----------------------------------------------------------------------
// <copyright file="Tool_ToolMetadata.cs" company="">
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
    public class Tool_ToolMetadata
    {
            [Display(Name="ID")]
            public global::System.Int32 idTool;

        [Display(Name = "Matricula")]
            public global::System.String Tag;

        [Display(Name = "Proveedor")]
            public Nullable<global::System.Int32> idSuplier;

        [Display(Name = "Tipo")]
            public Nullable<global::System.Int32> idType;

        [Display(Name = "Usuario Alta")]
            public Nullable<global::System.Int32> idUser;

        [Display(Name = "Activo")]
            public global::System.Boolean Active;

        [Display(Name = "Fecha Alta")]
            public global::System.DateTimeOffset InsDateTime;
        [Display(Name = "Fecha Actualización")]
           public global::System.DateTimeOffset UpdDateTime;
    }
}
