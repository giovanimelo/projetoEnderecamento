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
    public class EnderecamentoAPIController : ApiController
    {
        private readonly Repository _repository;
        public EnderecamentoAPIController()
        {
            _repository = new Repository();
        }

        private Contexto db = new Contexto();

        [HttpGet]
        public dynamic getEnderecamento()
        {
            return _repository.getEnderecamento();
        }
        [HttpPost]
        public dynamic postEnderecamento(string idproduto,string idendereco)
        {
            return _repository.postEnderecamento(idproduto,idendereco);
        }
        [HttpDelete]
        public dynamic deleteEnderecamento(string id)
        {
            return _repository.deleteEnderecamento(id);
        }
    }
}
