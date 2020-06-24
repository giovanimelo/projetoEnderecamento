using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Coluna
    {
        [Key]
        public int id_coluna { get; set; }
        [DisplayName("Nome Coluna")]
        public string nome_coluna { get; set; }
        [DisplayName("Vão")]
        public string nome_vao { get; set; }

    }
}