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
    public class Track_Person_RoleController : Controller
    {
        private Track_Person_RoleRepository db = new Track_Person_RoleRepository();

        public ActionResult Index(int? id)
        {
            Track track;
            if (id == null || (track = db.DBTrack.Find(id)) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var track_Person_Role = db.DBTrack_Genre.Include(t => t.Person).Include(t => t.Role).Include(t => t.Track).Where(t=>t.TrackId == track.Id).OrderBy(t=>t.PersonId);
            ViewBag.Track = track;
            return View(track_Person_Role.ToList());
        }       

        // GET: Track_Person_Role/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PersonId = new SelectList(db.DBPerson, "Id", "name");
            ViewBag.RoleId = new SelectList(db.DBRole, "Id", "role");
            return View(new Track_Person_Role() { TrackId = id.Value});
        }

        // POST: Track_Person_Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,TrackId,RoleId")] Track_Person_Role track_Person_Role)
        {
            if (ModelState.IsValid)
            {
                db.Add(track_Person_Role);
                return RedirectToAction("Index", new { id = track_Person_Role.TrackId });
            }

            ViewBag.PersonId = new SelectList(db.DBPerson, "Id", "name", track_Person_Role.PersonId);
            ViewBag.RoleId = new SelectList(db.DBRole, "Id", "role", track_Person_Role.RoleId);
            ViewBag.TrackId = new SelectList(db.DBTrack, "Id", "name", track_Person_Role.TrackId);
            return View(track_Person_Role);
        }

        // GET: Track_Person_Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track_Person_Role track_Person_Role = db.Find(id);
            if (track_Person_Role == null)
            {
                return HttpNotFound();
            }

            ViewBag.PersonId = new SelectList(db.DBPerson, "Id", "name", track_Person_Role.PersonId);
            ViewBag.RoleId = new SelectList(db.DBRole, "Id", "role", track_Person_Role.RoleId);
            return View(track_Person_Role);
        }

        // POST: Track_Person_Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonId,TrackId,RoleId")] Track_Person_Role track_Person_Role)
        {
            if (ModelState.IsValid)
            {
                db.Update(track_Person_Role);
                return RedirectToAction("Index", new { id = track_Person_Role.TrackId });
            }
            ViewBag.PersonId = new SelectList(db.DBPerson, "Id", "name", track_Person_Role.PersonId);
            ViewBag.RoleId = new SelectList(db.DBRole, "Id", "role", track_Person_Role.RoleId);
            ViewBag.TrackId = new SelectList(db.DBRole, "Id", "name", track_Person_Role.TrackId);
            return View(track_Person_Role);
        }

        // GET: Track_Person_Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track_Person_Role track_Person_Role = db.Find(id);
            if (track_Person_Role == null)
            {
                return HttpNotFound();
            }
            return View(track_Person_Role);
        }

        // POST: Track_Person_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Track_Person_Role track_Person_Role = db.Find(id);
            db.Delete(track_Person_Role);
            return RedirectToAction("Index", new { id = track_Person_Role.TrackId });
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
