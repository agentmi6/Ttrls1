using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineTuts.Models;
using Microsoft.AspNet.Identity;

namespace OnlineTuts.Controllers
{
    [Authorize]
    public class TutorialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tutorials
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var myTutorials = db.Tutorials.Where(x => x.ApplicationUserID == currentUser).ToList();

            return View(myTutorials);
        }


        public PartialViewResult Favorites()
        {
            var currentUserID = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserID);

            var myFavorites = currentUser.FavoritesByUser.ToList();

            return PartialView("_FavoritePartialView", myFavorites);
        }

        [HttpPost]
        public PartialViewResult RemoveFavorite(int id)
        {
            var currentTutorial = db.Favorites.Find(id);
            var currentUserID = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserID);

            var myFavorites = currentUser.FavoritesByUser.ToList();

            ViewBag.Favorite = currentTutorial.FavID;

            db.Favorites.Remove(currentTutorial);
            db.SaveChanges();

            return PartialView(myFavorites);
        }



        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            var allTutorials = db.Tutorials.ToList();
            Tutorial tutorial = db.Tutorials.Find(id);
            var tutorialID = tutorial.TutorialID;

            var vmodel = new UserVideoCommentViewModel
            {
                _tutorial = tutorial,
                _comment = new Comment(),
                _comments = db.Comments.Where(x => x.TutorialID == tutorialID),
                _Tutorials = allTutorials
            };

            ViewBag.UserName = tutorial.ApplicationUser.UserName;
            ViewBag.TutorialID = tutorial.TutorialID;

            return View(vmodel);
        }

        [HttpPost]
        public PartialViewResult Details(UserVideoCommentViewModel comment, int id)
        {
            var currentUser = User.Identity.GetUserId();
            var currentTutorial = db.Tutorials.Find(id);
            var tutorialID = currentTutorial.TutorialID;
            var allTutorials = db.Tutorials.ToList();

            var user = db.Users.Find(currentUser);

            ViewBag.TutorialID = tutorialID;

            comment._comment.ApplicationUser = user;
            comment._comment.TutorialID = tutorialID;
            comment._comment.ApplicationUserID = currentUser;
            comment._comment.CommentDateCreated = DateTime.Now;

            db.Comments.Add(comment._comment);
            db.SaveChanges();

            var commentsByTutorial = db.Comments.Where(x => x.TutorialID == tutorialID);

            var model = new UserVideoCommentViewModel
            {
                _tutorial = currentTutorial,
                _comment = comment._comment,
                _comments = commentsByTutorial,
                _Tutorials = allTutorials
            };

            return PartialView("_CommentPartialView", model);
        }



        // GET: Tutorials/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Tutorials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TutorialID,Name,VideoUrl,Description,ShortDescription,DateCreated,CategoryID,ApplicationUserID")] Tutorial tutorial)
        {
            if (ModelState.IsValid)
            {
                var currentUser = User.Identity.GetUserId();

                tutorial.ApplicationUserID = currentUser;
                tutorial.DateCreated = DateTime.Now;

                db.Tutorials.Add(tutorial);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", tutorial.CategoryID);
            return View(tutorial);
        }

        // GET: Tutorials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorial tutorial = db.Tutorials.Find(id);
            if (tutorial == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", tutorial.CategoryID);
            return View(tutorial);
        }

        // POST: Tutorials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TutorialID,Name,VideoUrl,Description,ShortDescription,DateCreated,CategoryID,ApplicationUserID")] Tutorial tutorial)
        {
            if (ModelState.IsValid)
            {
                tutorial.ApplicationUserID = User.Identity.GetUserId();
                db.Entry(tutorial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", tutorial.CategoryID);
            return View(tutorial);
        }

        // GET: Tutorials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorial tutorial = db.Tutorials.Find(id);
            if (tutorial == null)
            {
                return HttpNotFound();
            }
            return View(tutorial);
        }

        // POST: Tutorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutorial tutorial = db.Tutorials.Find(id);
            db.Tutorials.Remove(tutorial);
            db.SaveChanges();
            return RedirectToAction("Index");
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
