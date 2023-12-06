using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDACN.Models;
using WebDACN.Models.EF;

namespace WebDACN.Areas.Admin.Controllers
{
    public class CouponController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var coupons = db.Coupons.ToList();
            return View(coupons);
        }

        [HttpGet]
        public ActionResult CreateCoupon()
        {
            return View("CreateCoupon");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCoupon(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                coupon.StartDate = DateTime.Now;
                coupon.EndDate = DateTime.Now.AddDays(7);
                db.Coupons.Add(coupon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("CreateCoupon", coupon);
        }

        [HttpGet]
        public ActionResult EditCoupon(int id)
        {
            var coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }

            return View("EditCoupon", coupon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCoupon(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coupon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("EditCoupon", coupon);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Coupons.Find(id);
            if (item != null)
            {
                db.Coupons.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}