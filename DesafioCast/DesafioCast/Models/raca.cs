using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCast.Models
{
    public class raca
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo raça é obrigatório!")]
        public string nomeraca { get; set; }

        public virtual ICollection<animal> Animal { get; set; }

    }
}