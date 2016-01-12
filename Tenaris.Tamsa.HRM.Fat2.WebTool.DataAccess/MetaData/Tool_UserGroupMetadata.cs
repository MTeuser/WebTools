// -----------------------------------------------------------------------
// <copyright file="Tool_UserGroupMetadata.cs" company="">
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
    public class Tool_UserGroupMetadata
    {
        #region Primitive Properties

        [Display(Name = "Id")]
        public global::System.Int32 idUserGroup;

        [Display(Name = "Usuario")]
        public global::System.Int32 idUser;

        [Display(Name = "Grupo")]
        public global::System.Int32 idGroup;

        [Display(Name = "Activo")]
        public global::System.Boolean Active;

        [Display(Name = "Fecha de expiración")]
        public Nullable<global::System.DateTimeOffset> ExpirationDateTime;

        [Display(Name = "Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name = "Fecha de Actualizacion")]
        public global::System.DateTimeOffset UpdDateTime;

        #endregion
    }
}
