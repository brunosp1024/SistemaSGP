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
    public class ProjetoController : Controller
    {
        private ProjetoSGPContext db = new ProjetoSGPContext();

        // GET: Projeto
        public ActionResult Index()
        {
            return View(db.Projetoes.ToList());
        }

        // GET: Projeto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = db.Projetoes.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        // GET: Projeto/Create
        public ActionResult Create()
        {

            var lista = new[]
                    {
                        new SelectListItem { Value="1", Text = "Selecione", Selected = true},
                        new SelectListItem { Value="2", Text = "A iniciar"},
                        new SelectListItem { Value="3", Text = "Em andamento"},
                        new SelectListItem { Value="4", Text = "Concluído"},
                        new SelectListItem { Value="5", Text = "Cancelado"},
                    };

            ViewBag.Status = new SelectList(lista, "Text", "Text");
            return View();
        }

        // POST: Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProjeto,Nome,DataInicio,ValorContrato, Status")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                db.Projetoes.Add(projeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var lista = new[]
                    {
                        new SelectListItem { Value="1", Text = "Selecione", Selected = true},
                        new SelectListItem { Value="2", Text = "A iniciar"},
                        new SelectListItem { Value="3", Text = "Em andamento"},
                        new SelectListItem { Value="4", Text = "Concluído"},
                        new SelectListItem { Value="5", Text = "Cancelado"},
                    };

            ViewBag.Status = new SelectList(lista, "Text", "Text", projeto.Status);
            return View(projeto);
        }

        // GET: Projeto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = db.Projetoes.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }

            var lista = new[]
                    {
                        new SelectListItem { Value="1", Text = "Selecione", Selected = true},
                        new SelectListItem { Value="2", Text = "A iniciar"},
                        new SelectListItem { Value="3", Text = "Em andamento"},
                        new SelectListItem { Value="4", Text = "Concluído"},
                        new SelectListItem { Value="5", Text = "Cancelado"},
                    };

            ViewBag.Status = new SelectList(lista, "Text", "Text", projeto.Status);

            return View(projeto);
        }

        // POST: Projeto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProjeto,Nome,DataInicio,ValorContrato,Status")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {

                var lista = new[]
                    {
                        new SelectListItem { Value="1", Text = "Selecione", Selected = true},
                        new SelectListItem { Value="2", Text = "A iniciar"},
                        new SelectListItem { Value="3", Text = "Em andamento"},
                        new SelectListItem { Value="4", Text = "Concluído"},
                        new SelectListItem { Value="5", Text = "Cancelado"},
                    };

                ViewBag.Status = new SelectList(lista, "Text", "Text", projeto.Status);

                db.Entry(projeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projeto);
        }

        // GET: Projeto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = db.Projetoes.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projeto projeto = db.Projetoes.Find(id);
            db.Projetoes.Remove(projeto);
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
