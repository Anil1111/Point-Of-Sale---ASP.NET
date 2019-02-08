//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Point_Of_Sale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Unit
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(20, MinimumLength = 2)]
        public string UnitName { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(50, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string UnitDescription { get; set; }

        [Required]
        [Display(Name = "Primary Quantity")]
        public int UnitPrimaryQty { get; set; }
    }
}
