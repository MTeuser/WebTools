﻿// -----------------------------------------------------------------------
// <copyright file="Tool_PropertyMetadata.cs" company="">
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
    public class Tool_PropertyMetadata
    {
        #region Primitive Properties
        [Display(Name = "Id")]
        public global::System.Int32 idProperty;

        [Display(Name = "Tipo de dato")]
        public Nullable<global::System.Int32> dataType;

        [Display(Name = "Valor")]
        public global::System.String Value;

        [Display(Name="Nombre")]
        public global::System.String name;

        [Display(Name="Activo")]
        public global::System.Boolean Active;
        #endregion
    }
}
