// -----------------------------------------------------------------------
// <copyright file="Tool_ApplicationCommandMetadata.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess.AusV1
{
    using System;
     using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Tool_ApplicationCommandMetadata
    {
        #region Primitive Properties

        [Display(Name="Id Command")]
        public global::System.Int32 idApplicationCommand;

        [Display(Name = "Id Aplicación")]
        public global::System.Int32 idApplication;

        [Display(Name = "Command")]
        public global::System.String Command;

        [Display(Name = "Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name = "Fecha Actualización")]
        public global::System.DateTimeOffset UpdDateTime;

        #endregion
    }
}
