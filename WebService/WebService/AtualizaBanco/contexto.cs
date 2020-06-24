using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebService.Models;

namespace WebService.AtualizaBanco
{
    public class Contexto : DbContext
    {
        public Contexto()
              : base("dbprojeto")
        {

        }
        #region DBSET
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Coluna> Colunas { get; set; }
     
        public DbSet<Rua> Ruas { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Led> leds { get; set; }
        public DbSet<Enderecamento> enderecamentos { get; set; }


        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}