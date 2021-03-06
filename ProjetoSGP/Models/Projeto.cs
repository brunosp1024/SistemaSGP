﻿using System;
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

        [DisplayName("Projeto")]
        public string Nome { get; set; }

        [DisplayName("Data de Início")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Valor do Contrato")]
        public double ValorContrato { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }

    }
}