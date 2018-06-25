using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioCast.Models
{
    public class usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string nomeusuario { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        public string senha { get; set; }
    }
}