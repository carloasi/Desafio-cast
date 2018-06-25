using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCast.Models
{
    public class pessoa
    {
        [Key]
        public int id { get; set; }


        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string nome { get; set; }

        public string fone { get; set; }


        public virtual ICollection<adocao> adocao { get; set; }

    }
}