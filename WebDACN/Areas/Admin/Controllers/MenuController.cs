using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDACN.Models;
using WebDACN.Models.EF;

namespace WebDACN.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var items = db.Menus;

            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Menu model)
        {   
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebDACN.Models.Common.Filter.FilterChar(model.Title);// dùng filterChar convert tiếng việt có dấu thành ko dấu, tên miền, thay đổi đường dẫn thành chữ mình muốn
                db.Menus.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.Menus.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu model)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebDACN.Models.Common.Filter.FilterChar(model.Title);// IsModified = true đánh dấu rằng thuộc tính đã được thay đổi
                                                                                   // và cần cập nhật vào cơ sở dữ liệu khi chúng ta gọi phương thức SaveChanges() để lưu các thay đổi.
                db.Entry(model).Property(x => x.Title).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;//db.Entry(model) truy cập vào đối tượng model trong ngữ cảnh của DbContext (được đại diện bởi biến db).
                                                                               //Qua đó, chúng ta có thể thực hiện các thao tác với đối tượng này.
                db.Entry(model).Property(x => x.Link).IsModified = true;
                db.Entry(model).Property(x => x.Alias).IsModified = true;//.Property(x => x.Description) xác định thuộc tính cụ thể mà chúng ta muốn xác định rằng nó đã bị thay đổi.
                                                                         //Trong trường hợp này, thuộc tính là Description của đối tượng model.
                db.Entry(model).Property(x => x.Position).IsModified = true;
                db.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                db.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Menus.Find(id);
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                db.Menus.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}