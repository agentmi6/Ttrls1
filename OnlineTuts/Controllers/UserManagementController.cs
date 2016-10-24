using Microsoft.AspNet.Identity;
using OnlineTuts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTuts.Controllers
{
    public class UserManagementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult UserProfile(string name)

        {
            ApplicationDbContext db = new ApplicationDbContext();           

            var currentUser = db.Users.Where(x=>x.UserName == name).Single().UserName;
            var currentUserID = db.Users.Where(x => x.UserName == name).Single().Id;           

            ViewBag.CurrentUserName = currentUser;

            var model = new ProfileViewModel
            {
                _users = db.Users.Where(x => x.UserName == name),
                _tutorials = db.Tutorials.Where(x => x.ApplicationUser.UserName == name),
                _user = db.Users.Where(x=>x.UserName == name).Single(),
                _comments = db.Comments.Where(x=>x.ApplicationUser.UserName == name),
                _subs = db.Subs.Where(x=>x.ApplicationUserID == currentUserID),
                _favorites = db.Favorites.Where(x=>x.ApplicationUserID == currentUserID)
            };

            return View(model);
        }

        // id = name

        //public ActionResult UserProfile(string id)
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    ViewBag.CurrentUserID = id;

        //    var model = new ProfileViewModel
        //    {
        //        _users = db.Users.Where(x => x.Id == id),
        //        _tutorials = db.Tutorials.Where(x => x.ApplicationUserID == id),
        //        _user = db.Users.Find(id),
        //        _comments = db.Comments
        //    };

        //    return View(model);
        //}





        [HttpPost]
        public PartialViewResult Unsubscribe(string name)
        {
            var currentUser = User.Identity.GetUserId();
            var currentSub = db.Users.Where(x => x.UserName == name).First();
            var currentSubID = currentSub.Id;


            var mySubs = db.Subs.Where(x => x.ApplicationUserID == currentUser).ToList();
            var sub = mySubs.Where(x => x.SubUserID == currentSubID).First();

            ViewBag.UserName = currentSub.UserName;

            db.Subs.Remove(sub);
            db.SaveChanges();

            return PartialView("_Unsubscribe");
        }


        [HttpPost]
        public PartialViewResult Subscribe(Sub sub, string name)
        {
            var currentUserID = User.Identity.GetUserId();
            var newSub = db.Users.Where(x=>x.UserName == name).First();

            sub.ApplicationUserID = currentUserID;
            sub.SubUser = newSub;
            sub.SubName = newSub.UserName;
            sub.SubUserID = newSub.Id;

            ViewBag.UserName = newSub.UserName;

            db.Subs.Add(sub);
            db.SaveChanges();

            return PartialView("_Subscribe");
        }



        //GET: Subscriptions by user
        public PartialViewResult Subscriptions()
        {
            var currentUser = User.Identity.GetUserId();            

            var usersDB = db.Users.ToList();
            var tutorialsDB = db.Tutorials.Take(5).ToList();
            var subsDB = db.Subs.ToList();
                    
            ViewBag.CurrentUser = currentUser;

            var model = new UserSubscriptionsViewModel
            {
                _users = usersDB,
                _TutorialsBySubscriber = tutorialsDB,
                _subscriptions = subsDB
            };
           
            return PartialView("_Subscriptions",model);
        }

        [HttpPost]
        public PartialViewResult RemoveFromFavorites(int id)
        {
            var currentUser = User.Identity.GetUserId();
            var tutorial = db.Tutorials.Find(id);
            var tutorialID = tutorial.TutorialID;

            ViewBag.TutorialID = tutorialID;

            var favoriteTutorials = db.Favorites.Where(x => x.ApplicationUserID == currentUser).ToList();
            var favorite = favoriteTutorials.Where(x => x.TutorialID == tutorialID).First();

            db.Favorites.Remove(favorite);
            db.SaveChanges();

            return PartialView("_RemoveFromFavorites");
        }

        [HttpPost]
        public PartialViewResult AddToFavorites(Favorites fav, int id)
        {
            var currentUser = User.Identity.GetUserId();
            var tutorialToFav = db.Tutorials.Find(id);
            var tutorialID = tutorialToFav.TutorialID;

            ViewBag.TutorialID = tutorialID;

            fav.ApplicationUserID = currentUser;
            fav.TutorialID = tutorialID;

            db.Favorites.Add(fav);
            db.SaveChanges();

            return PartialView("_AddToFavorites");
        }
       
    }
}