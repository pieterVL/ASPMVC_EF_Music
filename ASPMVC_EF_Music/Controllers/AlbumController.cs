using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPMVC_EF_Music;
using System.Collections;
using DAL;
using DAL.Repository;

namespace ASPMVC_EF_Music.Controllers
{
    public class AlbumController : Controller
    {
        //private MusicContext db = new MusicContext();
        private AlbumRepository AlbumDB = new AlbumRepository();
        private Track_AlbumRepository T_aDB = new Track_AlbumRepository();


        // GET: Album
        public ActionResult Index()
        {
            return View(AlbumDB.GetAll());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = AlbumDB.Find(id);
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
                AlbumDB.Add(album);
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
            Album album = AlbumDB.Find(id);
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
                AlbumDB.Update(album);
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

            Album album = AlbumDB.Find(id);          

            if (album == null)
            {
                return HttpNotFound();
            }
            List<Track_Album> track_albums = T_aDB.GetAllTracksFromAlbum((int)id);
            IEnumerable<int> trackIDs = track_albums.Select(t_a => t_a.TrackId);

            IEnumerable<Track> AllTracks;
            using (TrackRepository TrackDB = new TrackRepository())
            {
                AllTracks = TrackDB.GetAll().Where(t => !trackIDs.Contains(t.Id));
            }

            ViewBag.TrackAlbumSelectList = AllTracks.Select(t => 
            new SelectListItem
            {
                Text = t.name,
                Value = t.Id.ToString()
            }).ToList();

            return View(new Track_AlbumCreateList()
            {
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
            T_aDB.Add(t_a);

            return RedirectToAction("Tracks", new { id = t_a.AlbumId });

        }

        // POST: Album/RemoveTrackLink/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveTrackLink(int id)
        {
            return null;
            //Track_Album t_a = db.Track_Album.Find(id);
            //db.Track_Album.Remove(t_a);
            //db.SaveChanges();
            //return RedirectToAction("Tracks",new {id= t_a.AlbumId });
            
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = AlbumDB.Find(id);
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
            Album album = AlbumDB.Find(id);
            AlbumDB.Delete(album);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                AlbumDB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
