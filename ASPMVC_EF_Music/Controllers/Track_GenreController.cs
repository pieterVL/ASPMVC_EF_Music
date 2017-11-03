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

        // GET: Track_Genre/index/5
        public ActionResult Index(int? id)
        {
            Track track;
            if (id == null || (track = db.DBTrack.Find(id)) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var track_Genre = db.DBTrack_Genre.Include(t => t.genre).Include(t => t.Track).Where(t=>t.TrackId==id);
            ViewBag.Track = track;
            return View(track_Genre.ToList());
        }

        // GET: Track_Genre/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.GenreID = new SelectList(db.DBGenre, "Id", "genreName");
            return View(new Track_Genre() {TrackId=id.Value});
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
                db.Add(track_Genre);
                return RedirectToAction("Index", new { id = track_Genre.TrackId});
            }

            ViewBag.GenreID = new SelectList(db.DBGenre, "Id", "genreName", track_Genre.GenreID);
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
                return RedirectToAction("Index", new { id = track_Genre.TrackId });
            }
            ViewBag.GenreID = new SelectList(db.DBGenre, "Id", "genreName", track_Genre.GenreID);
            return View(track_Genre);
        }

        // POST: Track_Genre/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Track_Genre track_Genre = db.DBTrack_Genre.Find(id);
            db.Delete(track_Genre);
            return RedirectToAction("Index", new { id = track_Genre.TrackId});
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
