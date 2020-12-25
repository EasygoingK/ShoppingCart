using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class testController : Controller
    {
        // GET: test
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetCart()
        {
            var cart = Operation.GetCurrentCart();
            cart.AddProduct(1);

            return Content($"目前購物車總共:{cart.TotalAmount}元");
        }
    }
}