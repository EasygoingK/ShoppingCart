namespace ShoppingCart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;


    [MetadataType(typeof(ProductCommentMetaData))]
    public partial class ProductComment
    {
        public string GetUserName()
        {
            using (UserEntities db = new UserEntities())
            {
                var data = db.AspNetUsers.Where(s => s.Id == this.UserId).Select(s => s.UserName).FirstOrDefault();

                return data;
            }
        }
    }
    
    public partial class ProductCommentMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Content { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> ProductId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string UserId { get; set; }
    }
}
