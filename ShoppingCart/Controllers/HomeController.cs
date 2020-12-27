using Microsoft.AspNet.Identity;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];

            using (CartEntities db = new CartEntities())
            {
                var data = db.Product.ToList();

                return View(data);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            using (CartEntities db = new CartEntities())
            {

                var productComment = db.ProductComment.Where(s => s.ProductId == id).ToList();

                ViewBag.ProductComment = productComment;

                var data = db.Product.Where(s => s.Id == id).FirstOrDefault();
                
                return View(data);
            }
        }

        [HttpPost]
        public ActionResult AddComment(int id, string Content)
        {

            var userId = HttpContext.User.Identity.GetUserId();

            var currentDateTime = DateTime.Now;

            var comment = new ProductComment()
            {
                ProductId = id,
                Content = Content,
                UserId = userId,
                CreateDate = currentDateTime
            };

            using (CartEntities db = new CartEntities())
            {
                db.ProductComment.Add(comment);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = id });
        }
    }
}