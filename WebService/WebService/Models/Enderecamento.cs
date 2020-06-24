using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Enderecamento
    {
        [Key]
        public int id_enderecamento { get; set; }
        [DisplayName("Endereço")]
        public int id_endereco { get; set; }
        public virtual Endereco endereco { get; set; }
        [DisplayName("produto")]
        public int id_produto { get; set; }
        public virtual Produto produto { get; set; }

    }
}