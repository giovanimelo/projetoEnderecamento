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
    public class HomeController : Controller
    {
        private Repository _repository = new Repository();
        private Contexto db = new Contexto();

        // GET: Enderecamento
        public ActionResult Index()
        {       
            return View();
        }

        public ActionResult Listar()
        {
            var data = _repository.getEnderecamento();
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
