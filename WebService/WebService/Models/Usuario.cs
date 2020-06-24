using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Usuario
    {
        [Key]
        [DisplayName("Id")]
        public int id_usuario { get; set; }
        [DisplayName("Nome")]
        public string no_nome { get; set; }
        [DisplayName("Sexo")]
        public string no_sexo { get; set; }
        
        [DisplayName("E-mail")]
        public string no_email { get; set; }
        [DisplayName("Telefone")]
        public string num_telefone { get; set; }
        [DisplayName("Senha")]
        public string no_senha { get; set; }
     
    }
}
