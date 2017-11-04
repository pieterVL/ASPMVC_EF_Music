using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsvHelper;
using DAL;
using DAL.Repository;
using System.IO;
using System.Text;

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

        public FileResult GetCSV() {
            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(db.GetAll());
                writer.Flush();
                stream.Position = 0;
                string text = reader.ReadToEnd();
                byte[] array = Encoding.ASCII.GetBytes(text);
                return File(array, System.Net.Mime.MediaTypeNames.Text.Plain);
            }

            //using (TextWriter fileReader = System.IO.File.CreateText(path))
            //{
            //    var csv = new CsvWriter(fileReader,);
            //    csv.WriteRecords(db.GetAll());
            //}
           ////return File(path, System.Net.Mime.MediaTypeNames.Text.Plain);
            //using (TextReader fileReader = System.IO.File.OpenText(path))
            //{
            //    var csv = new CsvReader(fileReader);
            //    csv.GetRecords<Track>();
            //}
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetCSV(string csvtxt)
        {
            //if (file != null && file.Length > 0)
            //{
            //    using (MemoryStream stream = new MemoryStream())
            //    {
            //        //file.InputStream.CopyTo(stream);
            //        //using (var reader = new StreamReader(stream))
            //        using (var reader = new StreamReader(file.InputStream))
            //        using (var csv = new CsvReader(reader)) {
            //            var records = csv.GetRecords<Track>();                            
            //            db.InsertBulk(records);
            //        }
            //    }
            //}
            using (StringReader stringReader = new StringReader(csvtxt))
            using (var csv = new CsvReader(stringReader)) {
                IEnumerable<Track> records = csv.GetRecords<Track>();
                db.InsertBulk(records);
            }
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
