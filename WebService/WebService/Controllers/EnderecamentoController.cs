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
    public class EnderecamentoController : Controller
    {
        private Repository _repository = new Repository();
        private Contexto db = new Contexto();

        // GET: Enderecamento
        public ActionResult Index()
        {
            var enderecamento = db.enderecamentos.Include(e => e.endereco).Include(e => e.produto);


            return View(enderecamento.ToList());
        }

        // GET: Enderecamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enderecamento enderecamento = db.enderecamentos.Find(id);
            if (enderecamento == null)
            {
                return HttpNotFound();
            }
            return View(enderecamento);
        }

        // GET: Enderecamento/Create
        public ActionResult Create()
        {
            var _enderecos = _repository.GetComboEnderecos();
            var _produtos = _repository.GetComboProdutos();


            ViewBag.id_endereco = new SelectList(_enderecos, "id_endereco", "descricao");
            ViewBag.id_produto = new SelectList(_produtos, "id_produto", "descricao");

            return View();
        }

        // POST: Enderecamento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_endereco,id_produto")] Enderecamento enderecamento)
        {
            if (ModelState.IsValid)
            {            
                    db.enderecamentos.Add(enderecamento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            return View(enderecamento);
        }

        // GET: Enderecamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enderecamento enderecamento = db.enderecamentos.Find(id);
            if (enderecamento == null)
            {
                return HttpNotFound();
            }
            return View(enderecamento);
        }

        // POST: Enderecamento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_endereco,id_produto")] Enderecamento enderecamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enderecamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enderecamento);
        }

        // GET: Enderecamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enderecamento enderecamento = db.enderecamentos.Find(id);
            if (enderecamento == null)
            {
                return HttpNotFound();
            }
            return View(enderecamento);
        }

        // POST: Enderecamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enderecamento enderecamento = db.enderecamentos.Find(id);
            db.enderecamentos.Remove(enderecamento);
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
