// -----------------------------------------------------------------------
// <copyright file="Tool_ProductionMetadata.cs" company="">
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
    public class Tool_ProductionMetadata
    {
        #region Primitive Properties

        [Display(Name="Id Produccion")]
        public global::System.Int32 idProduction;

        [Display(Name="Herramienta")]
        public Nullable<global::System.Int32> idTool;

        [Display(Name="Peso")]
        public Nullable<global::System.Double> weight;

        [Display(Name="Piezas")]
        public Nullable<global::System.Int32> pieces;

        [Display(Name="Colada")]
        public global::System.Int32 idHeatHistory;

        [Display(Name="Activo")]
        public global::System.Boolean Active;

        [Display(Name="Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name = "Fecha Actualización")]
        public global::System.DateTimeOffset UpdDateTime;

        #endregion
    }
}
