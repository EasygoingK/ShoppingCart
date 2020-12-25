using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ManageUserController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.ResultMessage = TempData["ResultMessage"];

            using (Entities db = new Entities())
            {
                var data = db.AspNetUsers.Select(s => new ManageUser { Id = s.Id, UserName = s.UserName, Email = s.Email });

                return View(data.ToList());
            }
        }

        public ActionResult Edit(string id)
        {
            using (Entities db = new Entities())
            {
                var data = db.AspNetUsers.Where(w => w.Id == id).Select(s => new ManageUser { Id = s.Id, UserName = s.UserName, Email = s.Email }).FirstOrDefault();

                if (data != default(ManageUser))
                {
                    return View(data);
                }

                TempData["ResultMessage"] = $"找不到該筆資料，請重新輸入!";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(string id, ManageUser editData)
        {
            if (ModelState.IsValid)
            {
                using (Entities db = new Entities())
                {
                    var data = db.AspNetUsers.FirstOrDefault(p => p.Id == id);

                    if (data != default(AspNetUsers))
                    {
                        data.UserName = editData.UserName;
                        data.Email = editData.Email;
                        db.SaveChanges();

                        TempData["ResultMessage"] = $"使用者{editData.UserName}編輯成功!";

                        return RedirectToAction("Index");
                    }
                }
            }

            TempData["ResultMessage"] = $"資料輸入有誤，請重新輸入!";

            return View(editData);
        }
    }
}