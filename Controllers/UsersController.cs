using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MISTeam8.DAL;
using MISTeam8.Models;

namespace MISTeam8.Controllers
{
    public class UsersController : Controller
    {
        private Team8Context db = new Team8Context();

        // GET: Users
        [Authorize]
        
        public ActionResult Index(string searchString)
        {
            var Users = from r in db.Users select r;
            Users = db.Users.OrderBy(r => r.lastname).ThenBy(r => r.firstname); ;
            if (!String.IsNullOrEmpty(searchString))
            {
                Users = Users.Where(r => r.lastname.Contains(searchString) || r.firstname.Contains(searchString)); 
            }   
            return View(Users);
        }

        // GET: Users/Details/5
        [Authorize]

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var rec = db.Recognitions.Where(r => r.UserID == id);
            var totalCnt = rec.Count(); //counts all the recognitions for that person
            ViewBag.totalrec = totalCnt;
            return View(user);
        }

        // GET: Users/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstname,lastname,email,tenure,position")] User user)
        {
            if (ModelState.IsValid)
            {
                Guid memberId;
                Guid.TryParse(User.Identity.GetUserId(), out memberId);
                user.ID = memberId;
                user.email = User.Identity.Name;
                user.tenure = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            Guid memberId;
            Guid.TryParse(User.Identity.GetUserId(), out memberId);
            if (id == memberId)
            {
                return View(user);
            }
            else
            {
                return View("NotAuthorized");
            }
            
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstname,lastname,email,tenure,position")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            Guid memberId;
            Guid.TryParse(User.Identity.GetUserId(), out memberId);
            if (id == memberId)
            {
                return View(user);
            }
            else
            {
                return View("NotAuthorized");
            }
           
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
    //hello 
}
