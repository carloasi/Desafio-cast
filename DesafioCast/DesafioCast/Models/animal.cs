using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCast.Models
{
    public class animal
    {


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Idade é obrigatório.")]
        public int idade { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "O campo Data de Entrada é obrigatório.")]
        public string dataEntrada { get; set; }

        public int racaId { get; set; }


        public virtual raca raca { get; set; }


        public virtual ICollection<adocao> adocao { get; set; }

    }
}