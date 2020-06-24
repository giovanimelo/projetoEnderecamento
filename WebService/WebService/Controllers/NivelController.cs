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
    public class NivelController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Nivel
        public ActionResult Index()
        {
            return View(db.Niveis.ToList());
        }

        // GET: Nivel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Niveis.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // GET: Nivel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nivel/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_coluna,numero_nivel")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Niveis.Add(nivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivel);
        }

        // GET: Nivel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Niveis.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Nivel/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_nivel,numero_nivel")] Nivel nivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivel);
        }

        // GET: Nivel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nivel nivel = db.Niveis.Find(id);
            if (nivel == null)
            {
                return HttpNotFound();
            }
            return View(nivel);
        }

        // POST: Nivel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nivel nivel = db.Niveis.Find(id);
            db.Niveis.Remove(nivel);
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
