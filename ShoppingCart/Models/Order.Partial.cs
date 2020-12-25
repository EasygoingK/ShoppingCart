namespace ShoppingCart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
    }
    
    public partial class OrderMetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RecieverName { get; set; }
        [Required]
        public string RecieverPhone { get; set; }
        [Required]
        public string RecieverAddress { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
