using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ManageOrderController : Controller
    {
        public ActionResult Index()
        {
            using (CartEntities db = new CartEntities())
            {
                var data = db.OrderSet.ToList();

                return View(data);
            }
        }

        public ActionResult Details(int id)
        {

            using (CartEntities db = new CartEntities())
            {
                var data = db.OrderDetailSet.Where(s => s.OrderId == id).ToList();

                return View(data);
            }
        }
    }
}