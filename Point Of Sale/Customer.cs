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

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Purchases = new HashSet<Purchase>();
        }
    
        public int ID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        [StringLength(50, MinimumLength = 2)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Order Number")]
        [StringLength(50, MinimumLength = 2)]
        public string OrderNumber { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [Display(Name = "Description")]
        [StringLength(500, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
