using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repository;

namespace ASPMVC_EF_Music.Controllers
{
    public class TrackController : Controller
    {
        private TrackRepository db = new TrackRepository();
         
        private List<String> ExtentionsList = new List<string>()
        {
              "mp3", "wav","3gp","ogg","mwa"
        };
        

        // GET: Track
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            ViewBag.Extentions = ExtentionsList;
            return View();
        }

        // POST: Track/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Extention,name,length")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Add(track);
                return RedirectToAction("Index");
            }

            return View(track);
        }

        // GET: Track/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.Extentions = ExtentionsList;
            return View(track);
        }

        // POST: Track/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Extention,name,length")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Update(track);
                return RedirectToAction("Index");
            }
            return View(track);
        }
       
        // GET: Track/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = db.Find(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Track/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track track = db.Find(id);
            db.Delete(track);
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
