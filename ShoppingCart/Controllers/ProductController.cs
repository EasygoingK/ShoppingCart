using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product createData)
        {
            if (ModelState.IsValid)
            {
                using (CartEntities db = new CartEntities())
                {
                    db.Product.Add(createData);
                    db.SaveChanges();

                    TempData["ResultMessage"] = $"商品{createData.Name}新增成功!";

                    return RedirectToAction("Index");
                }
            }

            TempData["ResultMessage"] = $"商品新增失敗!";

            return View(createData);
        }

        public ActionResult Edit(int id)
        {
            using (CartEntities db = new CartEntities())
            {
                var data = db.Product.FirstOrDefault(p => p.Id == id);

                if (data != default(Product))
                {
                    return View(data);
                }

                TempData["ResultMessage"] = $"資料有誤，請重新確認!";

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Product editData)
        {
            if (ModelState.IsValid)
            {
                using (CartEntities db = new CartEntities())
                {
                    var data = db.Product.FirstOrDefault(p => p.Id == id);

                        data.Name = editData.Name;
                        data.Description = editData.Description;
                        data.CategoryId = editData.CategoryId;
                        data.Price = editData.Price;
                        data.PublishDate = editData.PublishDate;
                        data.Status = editData.Status;
                        data.DefaultImageId = editData.DefaultImageId;
                        data.Quantity = editData.Quantity;
                        data.DefaultImageURL = editData.DefaultImageURL;   

                        db.SaveChanges();

                        TempData["ResultMessage"] = $"商品{editData.Name}編輯成功!";

                        return RedirectToAction("Index");
                    
                }
            }

            TempData["ResultMessage"] = $"資料有誤，請重新確認!";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (CartEntities db = new CartEntities())
            {
                var data = db.Product.FirstOrDefault(p => p.Id == id);

                if (data != default(Product))
                {
                    db.Product.Remove(data);
                    db.SaveChanges();

                    TempData["ResultMessage"] = $"商品{data.Name}刪除成功!";

                    return RedirectToAction("Index");
                }
            }

            TempData["ResultMessage"] = $"商品刪除失敗!";

            return RedirectToAction("Index");

        }

    }
}