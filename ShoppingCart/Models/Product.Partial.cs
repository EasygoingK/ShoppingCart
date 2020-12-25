namespace ShoppingCart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        [Required]
        [Display(Name = "編號")]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "售價")]
        public decimal Price { get; set; }

        [Required]
        public System.DateTime PublishDate { get; set; }

        [Required]
        public bool Status { get; set; }

        public Nullable<int> DefaultImageId { get; set; }

        [Required]
        [Display(Name = "庫存")]
        public int Quantity { get; set; }

        public string DefaultImageURL { get; set; }

    }
}
