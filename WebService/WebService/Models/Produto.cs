using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Produto
    {
        [Key]
        public int id_produto { get; set; }
        [DisplayName("Descricao do Produto")]
        public string descricao { get; set; }
        [DisplayName("Quantidade")]
        public int quantidade { get; set; }
        [DisplayName("Lote")]
        public string lote { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime vencimento { get; set; }

    }
}