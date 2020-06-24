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
    public class ColunasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Colunas
        public ActionResult Index()
        {
            return View(db.Colunas.ToList());
        }

        // GET: Colunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coluna coluna = db.Colunas.Find(id);
            if (coluna == null)
            {
                return HttpNotFound();
            }
            return View(coluna);
        }

        // GET: Colunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colunas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_coluna,nome_coluna")] Coluna coluna)
        {
            if (ModelState.IsValid)
            {
                db.Colunas.Add(coluna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coluna);
        }

        // GET: Colunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coluna coluna = db.Colunas.Find(id);
            if (coluna == null)
            {
                return HttpNotFound();
            }
            return View(coluna);
        }

        // POST: Colunas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_coluna,nome_coluna")] Coluna coluna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coluna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coluna);
        }

        // GET: Colunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coluna coluna = db.Colunas.Find(id);
            if (coluna == null)
            {
                return HttpNotFound();
            }
            return View(coluna);
        }

        // POST: Colunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coluna coluna = db.Colunas.Find(id);
            db.Colunas.Remove(coluna);
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
