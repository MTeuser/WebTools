// -----------------------------------------------------------------------
// <copyright file="PartialClasses.cs" company="">
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
     [MetadataType(typeof(Tool_ApplicationCommandMetadata))]
     public partial class ApplicationCommand { }

     [MetadataType(typeof(Tool_ApplicationMetadata))]
     public partial class Application { }

     [MetadataType(typeof(Tool_GroupMetadata))]
     public partial class Group { }

     [MetadataType(typeof(Tool_GroupPolicyMetadata))]
     public partial class GroupPolicy { }

     [MetadataType(typeof(Tool_HeatHistoryMetadata))]
     public partial class HeatHistory { }

     [MetadataType(typeof(Tool_ProductionMetadata))]
     public partial class Tool_Production { }

     [MetadataType(typeof(Tool_PropertyMetadata))]
     public partial class Tool_Property { }

     [MetadataType(typeof(Tool_SupplierMetadata))]
     public partial class Tool_Supplier { }

     [MetadataType(typeof(Tool_ToolDetailMetadata))]
     public partial class Tool_ToolDetail { }

     [MetadataType(typeof(Tool_ToolMetadata))]
     public partial class Tool_Tool { }

     [MetadataType(typeof(Tool_ToolTypeMetadata))]
     public partial class Tool_Type { }

     [MetadataType(typeof(Tool_UserGroupMetadata))]
     public partial class UserGroup { }

     [MetadataType(typeof(Tool_UserMetadata))]
     public partial class User { }   

}
