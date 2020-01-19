using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjetoSGP.Context
{
    public class ProjetoSGPContext : DbContext
    {

        public ProjetoSGPContext() : base("DbContext")
        {

        }

        public System.Data.Entity.DbSet<ProjetoSGP.Models.Atividade> Atividades { get; set; }

        public System.Data.Entity.DbSet<ProjetoSGP.Models.Recurso> Recursoes { get; set; }

        public System.Data.Entity.DbSet<ProjetoSGP.Models.Projeto> Projetoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();/*DESABILITAR CASCATAS*/
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Cria tabelas no banco sem pluralidades (Ex: Projetoes)
        }
    }


}