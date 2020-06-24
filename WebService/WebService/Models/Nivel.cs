using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Nivel
    {
        [Key]
        public int id_nivel { get; set; }
        [DisplayName("Numero Nível")]
        public string numero_nivel { get; set; }
    }
}