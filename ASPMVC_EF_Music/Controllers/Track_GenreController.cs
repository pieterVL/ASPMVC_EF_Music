using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repository;

namespace ASPMVC_EF_Music.Controllers
{
    public class Track_GenreController : Controller
    {
        private Track_GenreRepository db = new Track_GenreRepository();

        // GET: Track_Genre
        public ActionResult Index()
        {
            var track_Genre = db.DBTrack_Genre.Include(t => t.genre).Include(t => t.Track);
            return View(track_Genre.ToList());
        }

        // GET: Track_Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track_Genre track_Genre = db.DBTrack_Genre.Find(id);
            if (track_Genre == null)
            {
                return HttpNotFound();
            }
            return View(track_Genre);
        }

        // GET: Track_Genre/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.DBGenre, "Id", "genreName");
            ViewBag.TrackId = new SelectList(db.DBTrack, "Id", "name");
            return View();
        }

        // POST: Track_Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TrackId,GenreID")] Track_Genre track_Genre)
        {
            if (ModelState.IsValid)
            {
                db.DBTrack_Genre.Add(track_Genre);
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.DBGenre, "Id", "genreName", track_Genre.GenreID);
            ViewBag.TrackId = new SelectList(db.DBGenre, "Id", "name", track_Genre.TrackId);
            return View(track_Genre);
        }

        // GET: Track_Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track_Genre track_Genre = db.DBTrack_Genre.Find(id);
            if (track_Genre == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.DBGenre, "Id", "genreName", track_Genre.GenreID);
            ViewBag.TrackId = new SelectList(db.DBTrack, "Id", "name", track_Genre.TrackId);
            return View(track_Genre);
        }

        // POST: Track_Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrackId,GenreID")] Track_Genre track_Genre)
        {
            if (ModelState.IsValid)
            {
                db.Update(track_Genre);
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.DBGenre, "Id", "genreName", track_Genre.GenreID);
            ViewBag.TrackId = new SelectList(db.DBTrack, "Id", "name", track_Genre.TrackId);
            return View(track_Genre);
        }

        // GET: Track_Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track_Genre track_Genre = db.DBTrack_Genre.Find(id);
            if (track_Genre == null)
            {
                return HttpNotFound();
            }
            return View(track_Genre);
        }

        // POST: Track_Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track_Genre track_Genre = db.DBTrack_Genre.Find(id);
            db.Delete(track_Genre);
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
