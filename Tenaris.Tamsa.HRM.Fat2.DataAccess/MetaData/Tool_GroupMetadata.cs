// -----------------------------------------------------------------------
// <copyright file="Tool_GroupMetadata.cs" company="">
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
    public class Tool_GroupMetadata
    {
        #region Primitive Properties

        [Display(Name = "Id Grupo")]
        public global::System.Int32 idGroup;

        [Display(Name = "Zona")]
        public global::System.Int32 idZone;

        [Display(Name = "Codigo")]
        public global::System.String Code;

        [Display(Name = "Nombre")]
        public global::System.String Name;

        [Display(Name = "Descripción")]
        public global::System.String Description;

        [Display(Name = "Activo")]
        public global::System.Boolean Active;

        [Display(Name = "Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name = "Fecha Actualización")]
        public global::System.DateTimeOffset UpdDateTime;
        #endregion
    }
}
