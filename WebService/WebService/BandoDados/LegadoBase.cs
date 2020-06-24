using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public abstract class LegadoBase
    {
        protected Data db = null;
        public LegadoBase() => DATA();

        public void DATA()
        {
            db = new Data();
            db.Servidor = "den1.mssql7.gear.host";
            // db.Porta = 8080;
            db.Usuario = "dbprojeto";
            db.Senha = "Timao.1994";
            db.Tipo = "SQL";
        }
    }
}