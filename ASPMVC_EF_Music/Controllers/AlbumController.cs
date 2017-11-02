using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPMVC_EF_Music;
using ASPMVC_EF_Music.DAL;
using System.Collections;

namespace ASPMVC_EF_Music.Controllers
{
    public class AlbumController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Album
        public ActionResult Index()
        {
            return View(db.Albums.ToList());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,releasedate")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,releasedate")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Album/Tracks/5
        public ActionResult Tracks(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = db.Albums.Find(id);          

            if (album == null)
            {
                return HttpNotFound();
            }
            List<Track_Album> track_albums
                = db.Track_Album.Where(t_a => t_a.AlbumId == album.Id).OrderBy(t_a => t_a.TrackSequence).ToList();

            //need optimazation - no client side filtering
            track_albums.ForEach(t_a => t_a.Track 
                = db.Tracks.Where(t => t.Id == t_a.TrackId).First()
            );

            List<Track> AllTracks = db.Tracks.ToList();//need only tracks that are not in this album yet

            List<SelectListItem> SelectlistItems = new List<SelectListItem>();
            ViewBag.TrackAlbumSelectList = SelectlistItems;

            AllTracks.ForEach(t => SelectlistItems.Add(new SelectListItem() {
                Text=t.name,
                Value=t.Id.ToString()
            }));

            return View(new Track_AlbumCreateList() {
                track_album = new Track_Album(),
                ExistingTrack_Albums = track_albums
            });
        }
        // POST: Album/Tracks/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tracks(int id, [Bind(Include = "TrackId,TrackSequence")] Track_Album t_a)
        {
            t_a.AlbumId = id;
            //Track_Album t_a = db.Track_Album.Find(id);
            //db.Track_Album.Remove(t_a);
            db.Track_Album.Add(t_a);
            db.SaveChanges();
            return RedirectToAction("Tracks", new { id = t_a.AlbumId });

        }

        // POST: Album/RemoveTrackLink/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveTrackLink(int id)
        {
            Track_Album t_a = db.Track_Album.Find(id);
            db.Track_Album.Remove(t_a);
            db.SaveChanges();
            return RedirectToAction("Tracks",new {id= t_a.AlbumId });
            
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
