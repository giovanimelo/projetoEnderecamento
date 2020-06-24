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
    public class EnderecoAPIController : ApiController
    {
        private readonly Repository _repository;
        public EnderecoAPIController()
        {
            _repository = new Repository();
        }

        private Contexto db = new Contexto();


        [HttpGet]
        public List<Validade_Lote> getValidadeLote()
        {
            return _repository.GetValidadeLote();
        }

    }
}
