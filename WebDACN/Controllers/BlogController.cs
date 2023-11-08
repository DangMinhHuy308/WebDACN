using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDACN.Models;

namespace WebDACN.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string alias)
        {
            var item = db.Posts.FirstOrDefault(x => x.Alias == alias);
            return View(item);
        }
    }
}