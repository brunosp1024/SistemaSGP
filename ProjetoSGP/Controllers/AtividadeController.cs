using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoSGP.Context;
using ProjetoSGP.Models;

namespace ProjetoSGP.Controllers
{
    public class AtividadeController : Controller
    {
        private ProjetoSGPContext db = new ProjetoSGPContext();

        // GET: Atividade
        public ActionResult Index()
        {
            var atividades = db.Atividades.Include(a => a.Projeto).Include(a => a.Recurso);
            return View(atividades.ToList());
        }

        // GET: Atividade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        // GET: Atividade/Create
        public ActionResult Create()
        {
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "Nome");
            ViewBag.IdRecurso = new SelectList(db.Recursoes, "IdRecurso", "Nome");
            return PartialView();
        }

        // POST: Atividade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAtividade,Nome,DataInicio,DataTermino,Duracao,IdRecurso,IdProjeto")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                db.Atividades.Add(atividade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "Nome", atividade.IdProjeto);
            ViewBag.IdRecurso = new SelectList(db.Recursoes, "IdRecurso", "Nome", atividade.IdRecurso);
            return PartialView(atividade);
        }

        // GET: Atividade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "Nome", atividade.IdProjeto);
            ViewBag.IdRecurso = new SelectList(db.Recursoes, "IdRecurso", "Nome", atividade.IdRecurso);
            return View(atividade);
        }

        // POST: Atividade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAtividade,Nome,DataInicio,DataTermino,Duracao,IdRecurso,IdProjeto")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProjeto = new SelectList(db.Projetoes, "IdProjeto", "Nome", atividade.IdProjeto);
            ViewBag.IdRecurso = new SelectList(db.Recursoes, "IdRecurso", "Nome", atividade.IdRecurso);
            return View(atividade);
        }

        // GET: Atividade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividade atividade = db.Atividades.Find(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        // POST: Atividade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atividade atividade = db.Atividades.Find(id);
            db.Atividades.Remove(atividade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
