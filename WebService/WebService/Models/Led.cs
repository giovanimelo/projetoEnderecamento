using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Led
    {
        [Key]
        public int id_led { get; set; }
        [DisplayName("Numero da Led")]
        public int numero { get; set; }
      
    }
}