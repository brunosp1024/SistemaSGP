using ProjetoSGP.Context;
using ProjetoSGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                Nome = "[--Selecione um Recurso--]"
            });

            return rec = rec.OrderBy(r => r.Nome).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}