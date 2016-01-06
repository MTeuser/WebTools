// -----------------------------------------------------------------------
// <copyright file="Tool_ApplicationMetadata.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.Tamsa.HRM.Fat2.WebTool.DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Tool_ApplicationMetadata
    {
        #region Primitive Properties

        [Display(Name = "Id Aplicación")]
        public global::System.Int32 idApplication;

        [Display(Name = "Codigo")]
        public global::System.String Code;

        [Display(Name = "Nombre")]
        public global::System.String Name;

        [Display(Name = "Descripción")]
        public global::System.String Description;

        [Display(Name = "Manager")]
        public global::System.Boolean IsManager;

        [Display(Name = "Archivo")]
        public global::System.String FileName;

        [Display(Name = "Activo")]
        public global::System.Boolean Active;

        [Display(Name = "Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name = "Fecha Actualización")]
        public global::System.DateTimeOffset UpdDateTime;

        #endregion
    }
}
