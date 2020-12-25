namespace ShoppingCart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [MetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
        public string GetUrderName()
        {
            using (Entities db = new Entities())
            {
                var data = db.AspNetUsers.Where(s => s.Id == this.UserId).Select(s => s.UserName).FirstOrDefault();

                return data;
            }
        }
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
