﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Ship
    {
        [Display(Name ="收貨人姓名")]
        [StringLength(30,ErrorMessage = "{0}的長度至少必須為{2}個字元",MinimumLength = 2)]
        public string RecieverName { get; set; }

        [Display(Name = "收貨人電話")]
        [StringLength(15, ErrorMessage = "{0}的長度至少必須為{2}個字元", MinimumLength = 8)]
        public string RecieverPhone { get; set; }

        [Display(Name = "收貨人地址")]
        [StringLength(256, ErrorMessage = "{0}的長度至少必須為{2}個字元", MinimumLength = 8)]
        public string RecieverAddress { get; set; }
    }
}