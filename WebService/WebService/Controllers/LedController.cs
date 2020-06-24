using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebService.AtualizaBanco;
using WebService.Models;

namespace WebService.Controllers
{
    public class LedController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Led
        public ActionResult Index()
        {
            return View(db.leds.ToList());
        }

        // GET: Led/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Led led = db.leds.Find(id);
            if (led == null)
            {
                return HttpNotFound();
            }
            return View(led);
        }

        // GET: Led/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Led/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,numero")] Led led)
        {
            if (ModelState.IsValid)
            {
                db.leds.Add(led);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(led);
        }

        // GET: Led/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Led led = db.leds.Find(id);
            if (led == null)
            {
                return HttpNotFound();
            }
            return View(led);
        }

        // POST: Led/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,numero")] Led led)
        {
            if (ModelState.IsValid)
            {
                db.Entry(led).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(led);
        }

        // GET: Led/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Led led = db.leds.Find(id);
            if (led == null)
            {
                return HttpNotFound();
            }
            return View(led);
        }

        // POST: Led/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Led led = db.leds.Find(id);
            db.leds.Remove(led);
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
