using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSGP.Models
{
    public class Atividade
    {

        [Key]
        [DisplayName("Id")] //Exibe o nome Id ao invés de IdAtividade
        public int IdAtividade { get; set; }

        [DisplayName("Atividade")]
        public string Nome { get; set; }

        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data de Término")]
        public DateTime DataTermino { get; set; }

        [DisplayName("Duração")]
        public int Duracao { get; set; }

        [DisplayName("Recurso")]
        public int IdRecurso { get; set; }

        [DisplayName("Projeto")]
        public int IdProjeto { get; set; }

        public virtual Recurso Recurso { get; set; }

        public virtual Projeto Projeto { get; set; }

    }
}