using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoSGP.Models
{
    public class Projeto
    {

        [Key]
        [DisplayName("Id")]
        public int IdProjeto { get; set; }

        public string Nome { get; set; }

        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }

        public ICollection<string> Status { get; set; }

        [DisplayName("Valor do Contrato")]
        public double ValorContrato { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }

    }
}