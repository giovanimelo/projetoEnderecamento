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
    public class RuaController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Rua
        public ActionResult Index()
        {
            return View(db.Ruas.ToList());
        }

        // GET: Rua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rua rua = db.Ruas.Find(id);
            if (rua == null)
            {
                return HttpNotFound();
            }
            return View(rua);
        }

        // GET: Rua/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rua/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_coluna,nome_rua")] Rua rua)
        {
            if (ModelState.IsValid)
            {
                db.Ruas.Add(rua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rua);
        }

        // GET: Rua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rua rua = db.Ruas.Find(id);
            if (rua == null)
            {
                return HttpNotFound();
            }
            return View(rua);
        }

        // POST: Rua/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_rua,nome_rua")] Rua rua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rua);
        }

        // GET: Rua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rua rua = db.Ruas.Find(id);
            if (rua == null)
            {
                return HttpNotFound();
            }
            return View(rua);
        }

        // POST: Rua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rua rua = db.Ruas.Find(id);
            db.Ruas.Remove(rua);
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
