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
    public class RecognitionsController : Controller
    {
        private Team8Context db = new Team8Context();

        [Authorize]
        // GET: Recognitions
        public ActionResult Index()
        {
            var recognitions = db.Recognitions.Include(r => r.Recognizor).Include(r => r.Users);
            return View(recognitions.ToList());

        }

        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: Recognitions/Create
        [Authorize]
        public ActionResult Create()
        {
            // ViewBag.recognizorID = new SelectList(db.Users, "ID", "fullname");
            string UserID = User.Identity.GetUserId();
            SelectList users = new SelectList(db.Users, "ID", "fullname");
            users = new SelectList(users.Where(x => x.Value != UserID).ToList(), "Value", "Text");
            ViewBag.UserID = users;
            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecognitionID,UserID,award,recognizorID,DateRecongized,Details")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                Guid memberId;
                Guid.TryParse(User.Identity.GetUserId(), out memberId);
                recognition.recognizorID = memberId;
                db.Recognitions.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.recognizorID = new SelectList(db.Users, "ID", "fullname", recognition.recognizorID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "fullname", recognition.UserID);
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            Guid memberId;
            Guid.TryParse(User.Identity.GetUserId(), out memberId);
            if (recognition.recognizorID == memberId)
            {
                ViewBag.recognizorID = new SelectList(db.Users, "ID", "fullname", recognition.recognizorID);
                ViewBag.UserID = new SelectList(db.Users, "ID", "fullname", recognition.UserID);
                return View(recognition);
            }
            else
            {
                return View("NotAuthorized");
            }

            
            
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecognitionID,UserID,award,recognizorID,DateRecongized,Details")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.recognizorID = new SelectList(db.Users, "ID", "fullname", recognition.recognizorID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "fullname", recognition.UserID);
            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            Guid memberId;
            Guid.TryParse(User.Identity.GetUserId(), out memberId);
            if (recognition.recognizorID == memberId)
            {
                return View(recognition);
            }
            else
            {
                return View("NotAuthorized");
            }
            
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognition recognition = db.Recognitions.Find(id);
            db.Recognitions.Remove(recognition);
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
