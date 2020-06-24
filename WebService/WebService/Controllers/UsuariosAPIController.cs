using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using WebService.AtualizaBanco;
using WebService.BandoDados;
using WebService.Models;

namespace WebService.Controllers
{
    public class UsuariosAPIController : ApiController
    {
        private readonly Repository _repository;
        public UsuariosAPIController()
        {
            _repository = new Repository();
        }

        private Contexto db = new Contexto();


        [HttpGet]
        public string getusuario(string email, string senha)
        {
            return _repository.GetUsuario( email,  senha);
        }
    }
}
