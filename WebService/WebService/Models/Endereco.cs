using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Endereco
    {
        [Key]
        public int id_endereco { get; set; }
        [DisplayName("Descricao do Endereço")]
        public string descricao { get; set; }   
        [DisplayName("Rua")]
        public int id_rua { get; set; }
        public virtual Rua rua { get; set; }
        [DisplayName("Coluna")]
        public int id_coluna { get; set; }
        public virtual Coluna coluna { get; set; }
        [DisplayName("Nivel")]
        public int id_nivel { get; set; }
        public virtual Nivel nivel { get; set; }
        [DisplayName("Led")]
        public int id_led { get; set; }
        public virtual Led led { get; set; }
        public string codigo_qr { get; set; }

    }
}