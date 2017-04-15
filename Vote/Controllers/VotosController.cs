using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vote.DAO;
using Vote.Models;

namespace Vote.Controllers
{
    public class VotosController : Controller
    {
        private VoteEF db = new VoteEF();

        // GET: Votos
        public ActionResult Index()
        {
            List<VotoViewModel> votos = db.Votos.Include(v => v.Funcionario).Include(v => v.Restaurante).Select(v=> new VotoViewModel() {  Funcionario = v.Funcionario, Restaurante = v.Restaurante, Id = v.Id}).ToList();
            return View(votos);
        }

        // GET: Votos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voto voto = db.Votos.Find(id);
            if (voto == null)
            {
                return HttpNotFound();
            }
            return View(voto);
        }

        // GET: Votos/Create
        public ActionResult Create()
        {
            ViewBag.IdFuncionario = new SelectList(db.Funcionarios, "Id", "Ativo");
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "Id", "Endereco");
            return View();
        }

        // POST: Votos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdRestaurante,IdFuncionario,DataVoto")] Voto voto)
        {
            if (ModelState.IsValid)
            {
                db.Votos.Add(voto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFuncionario = new SelectList(db.Funcionarios, "Id", "Ativo", voto.IdFuncionario);
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "Id", "Endereco", voto.IdRestaurante);
            return View(voto);
        }

        // GET: Votos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voto voto = db.Votos.Find(id);
            if (voto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFuncionario = new SelectList(db.Funcionarios, "Id", "Ativo", voto.IdFuncionario);
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "Id", "Endereco", voto.IdRestaurante);
            return View(voto);
        }

        // POST: Votos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdRestaurante,IdFuncionario,DataVoto")] Voto voto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFuncionario = new SelectList(db.Funcionarios, "Id", "Ativo", voto.IdFuncionario);
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes, "Id", "Endereco", voto.IdRestaurante);
            return View(voto);
        }

        // GET: Votos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voto voto = db.Votos.Find(id);
            if (voto == null)
            {
                return HttpNotFound();
            }
            return View(voto);
        }

        // POST: Votos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voto voto = db.Votos.Find(id);
            db.Votos.Remove(voto);
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
