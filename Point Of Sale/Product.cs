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

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductPrices = new HashSet<ProductPrice>();
            this.ProductImages = new HashSet<ProductImage>();
            this.Purchases = new HashSet<Purchase>();
        }
    
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(20, MinimumLength = 2)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Code of product")]
        [StringLength(20, MinimumLength = 2)]
        public string ProductCode { get; set; }

        [Required]
        [Display(Name = "Quentity")]
        public int ProductQuentity { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }

        [Required]
        [Display(Name = "Position of product")]
        [StringLength(200, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        public string ProductPosition { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandID { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
