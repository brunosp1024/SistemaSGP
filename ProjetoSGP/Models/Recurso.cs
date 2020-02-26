using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSGP.Models
{
    public class Recurso
    {

        [Key]
        [DisplayName("Id")]
        public int IdRecurso { get; set; }

        [DisplayName("Recurso")]
        public string Nome { get; set; }

        [DisplayName("E-Mail")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }

    }
}