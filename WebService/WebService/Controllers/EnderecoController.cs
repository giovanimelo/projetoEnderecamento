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
    public class EnderecoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Endereco
        public ActionResult Index()
        {
            var enderecos = db.Enderecos.Include(e => e.coluna).Include(e => e.nivel).Include(e => e.rua);
            return View(enderecos.ToList());
        }

        // GET: Endereco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            ViewBag.id_coluna = new SelectList(db.Colunas, "id_coluna", "nome_coluna");
            ViewBag.id_nivel = new SelectList(db.Niveis, "id_nivel", "numero_nivel");
            ViewBag.id_rua = new SelectList(db.Ruas, "id_rua", "nome_rua");
            ViewBag.id_led = new SelectList(db.leds, "id_led", "numero");
            return View();
        }

        // POST: Endereco/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,id_rua,id_coluna,id_nivel,id_led")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                endereco.codigo_qr = "id_endereco=" + endereco.id_endereco.ToString()+ "-" + "id_led=" + endereco.id_led.ToString();
                db.Enderecos.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_coluna = new SelectList(db.Colunas, "id_coluna", "nome_coluna", endereco.id_coluna);
            ViewBag.id_nivel = new SelectList(db.Niveis, "id_nivel", "numero_nivel", endereco.id_nivel);
            ViewBag.id_rua = new SelectList(db.Ruas, "id_rua", "nome_rua", endereco.id_rua);
            ViewBag.id_led = new SelectList(db.leds, "id_led", "numero", endereco.id_led);
            return View(endereco);
        }

        // GET: Endereco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_coluna = new SelectList(db.Colunas, "id_coluna", "nome_coluna", endereco.id_coluna);
            ViewBag.id_nivel = new SelectList(db.Niveis, "id_nivel", "numero_nivel", endereco.id_nivel);
            ViewBag.id_rua = new SelectList(db.Ruas, "id_rua", "nome_rua", endereco.id_rua);
            ViewBag.id_led = new SelectList(db.leds, "id_led", "numero", endereco.id_led);
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_endereco,descricao,id_rua,id_coluna,id_nivel,id_led")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_coluna = new SelectList(db.Colunas, "id_coluna", "nome_coluna", endereco.id_coluna);
            ViewBag.id_nivel = new SelectList(db.Niveis, "id_nivel", "numero_nivel", endereco.id_nivel);
            ViewBag.id_rua = new SelectList(db.Ruas, "id_rua", "nome_rua", endereco.id_rua);
            ViewBag.id_led = new SelectList(db.Ruas, "id_led", "numero", endereco.id_led);
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Enderecos.Find(id);
            db.Enderecos.Remove(endereco);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Listar()
        {
            var data = db.Enderecos.ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
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
