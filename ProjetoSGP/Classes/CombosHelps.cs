using ProjetoSGP.Context;
using ProjetoSGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSGP.Classes
{
    public class CombosHelps : IDisposable
    {

        private static ProjetoSGPContext db = new ProjetoSGPContext();
        public static List<Recurso> GetRecursos()
        {

            var rec = db.Recursoes.ToList();
            rec.Add(new Recurso
            {
                IdRecurso = 0,
            });

            return rec = rec.OrderBy(r => r.Nome).ToList();
        }

        public static List<Atividade> GetAtividades()
        {

            var rec = db.Atividades.ToList();

            return rec = rec.OrderBy(r => r.Nome).ToList();
        }

        public static List<SelectListItem> GetStatus()
        {


                var lista = new List<SelectListItem>
                    {
                        new SelectListItem { Text = "Selecione", Value="", Selected = true},
                        new SelectListItem { Text = "A iniciar", Value="1"},
                        new SelectListItem { Text = "Em andamento", Value="2"},
                        new SelectListItem { Text = "Concluído", Value="3"},
                        new SelectListItem { Text = "Cancelado", Value="4"},

                    };

            return lista;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}