using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCast.Models
{
    public class adocao
    {
        [Key]
        public int Id { get; set; }

        public string DataAdocao { get; set; }

        public int pessoaId { get; set; }

        public int animalId { get; set; }

        public virtual pessoa pessoa { get; set; }

        public virtual animal animal { get; set; }

    }
}