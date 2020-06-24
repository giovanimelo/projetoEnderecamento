using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class EnderecamentoAPI
    {
        [DisplayName("Endereço")]
        public string descricao_endereco { get; set; }
        [DisplayName("Coluna")]
        public string descricao_column { get; set; }
        [DisplayName("Rua")]
        public string descricao_rua { get; set; }
        [DisplayName("Nivel")]
        public string descricao_nivel { get; set; }
        [DisplayName("Produto")]
        public string descricao_produto { get; set; }
        [DisplayName("Qtde")]
        public string quantidade { get; set; }
        [DisplayName("Vencimento")]
        public string vencimento { get; set; }
    }
}