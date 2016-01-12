// -----------------------------------------------------------------------
// <copyright file="Tool_UserMetadata.cs" company="">
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
    public class Tool_UserMetadata
    {
        #region Primitive Properties

        [Display(Name = "Id")]
        public global::System.Int32 idUser;

        [Display(Name = "Identificacion")]
        public global::System.String Identification;

        [Display(Name = "Contraseña")]
        public global::System.String Password;

        [Display(Name = "Apellido")]
        public global::System.String LastName;

        [Display(Name = "Nombre")]
        public global::System.String FirstName;

        [Display(Name = "Imagen")]
        public global::System.Byte[] Picture;

        [Display(Name = "Correo electronico")]
        public global::System.String Email;

        [Display(Name = "Activo")]
        public global::System.Boolean Active;

        [Display(Name = "Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name = "Fecha Actualizacion")]
        public global::System.DateTimeOffset UpdDateTime;

        #endregion
    }
}
