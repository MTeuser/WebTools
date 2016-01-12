// -----------------------------------------------------------------------
// <copyright file="Tool_HeatHistoryMetadata.cs" company="">
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
    public class Tool_HeatHistoryMetadata
    {
        #region Primitive Properties

        [Display(Name = "Id Colada")]
        public global::System.Int32 idHeatHistory;

        [Display(Name = "Acero")]
        public global::System.String SteelCode;

        [Display(Name = "Numero")]
        public global::System.Int32 HeatNumber;

        [Display(Name = "Color Stencil")]
        public global::System.String StencilColor;

        [Display(Name = "Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        #endregion
    }
}
