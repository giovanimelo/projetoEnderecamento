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
    public class ProdutoAPIController : ApiController
    {
        private readonly Repository _repository;
        public ProdutoAPIController()
        {
            _repository = new Repository();
        }

        private Contexto db = new Contexto();

        public List<Produto> getComboProdutos()
        {
            return _repository.GetComboProdutos();
        }
        public List<ProdutoQtde> getProdutoQtde()
        {
            return _repository.getProdutosQtde();
        }
        public List<Produto> GetProdutos(string descricao)
        {
            return _repository.GetProdutos(descricao);
        }

    }
}
