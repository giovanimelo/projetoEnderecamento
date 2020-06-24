using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Rua
    {
        [Key]
        public int id_rua { get; set; }
        [DisplayName("Nome Rua")]
        public string nome_rua { get; set; }
    }
}