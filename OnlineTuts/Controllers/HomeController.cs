using OnlineTuts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;

namespace OnlineTuts.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
                                 
       
        public ActionResult Index(int? page)
        {

            ViewBag.CurrentUserID = User.Identity.GetUserId();

            var allTutorials =
                (from t in db.Tutorials
                select t).ToList();

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View("Index", "_Layout2", allTutorials.ToPagedList(pageNumber, pageSize));           
        }

        public ActionResult Category(int id)
        {
            var TutorialsByCategory = db.Tutorials.Where(x => x.Category.CategoryID == id).ToList();
            return View(TutorialsByCategory);
        }


    }
}