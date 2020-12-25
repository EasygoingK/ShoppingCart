using Microsoft.AspNet.Identity;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Ship postback)
        {
            if (ModelState.IsValid)
            {
                var currentCart = Operation.GetCurrentCart();

                var userId = HttpContext.User.Identity.GetUserId();

                using (CartEntities db = new CartEntities())
                {
                    var order = new Order()
                    {
                        UserId = userId,
                        RecieverName = postback.RecieverName,
                        RecieverPhone = postback.RecieverPhone,
                        RecieverAddress = postback.RecieverAddress
                    };

                    db.OrderSet.Add(order);
                    db.SaveChanges();

                    var orderDetails = currentCart.ToOrderDetailList(order.Id);

                    db.OrderDetailSet.AddRange(orderDetails);
                    db.SaveChanges();
                    
                }

                return Content("訂購成功!");
            }

            return View();
        }
    }
}