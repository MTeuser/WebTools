// -----------------------------------------------------------------------
// <copyright file="Tool_ToolDetailMetadata.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Tool_ToolDetailMetadata
    {
        #region Primitive Properties

        [Display(Name = "Id")]
        public global::System.Int32 idToolDetail;

        [Display(Name = "Propiedad")]
        public Nullable<global::System.Int32> idProperty;

        [Display(Name = "Herramienta")]
        public Nullable<global::System.Int32> idTool;

        #endregion
    }
}
