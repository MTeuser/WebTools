// -----------------------------------------------------------------------
// <copyright file="Tool_GroupPolicyMetadata.cs" company="">
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
    public class Tool_GroupPolicyMetadata
    {
        [Display(Name="Id Politica")]
        public global::System.Int32 idGroupPolicy;

        [Display(Name="Grupo")]
        public global::System.Int32 idGroup;

        [Display(Name="Comando")]
        public global::System.Int32 idApplicationCommand;

        [Display(Name="Activo")]
        public global::System.Boolean Active;

        [Display(Name="Fecha Alta")]
        public global::System.DateTimeOffset InsDateTime;

        [Display(Name="Fecha  Actualización")]
        public global::System.DateTimeOffset UpdDateTime;
        
    }
}
