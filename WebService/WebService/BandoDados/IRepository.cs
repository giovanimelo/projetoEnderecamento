using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService.BandoDados
{
    public interface IRepository
    {
       string GetUsuario(string email, string senha);
       List<Validade_Lote> GetValidadeLote();

    }
}