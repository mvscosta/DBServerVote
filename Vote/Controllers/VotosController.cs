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
using Vote.Roles;

namespace Vote.Controllers
{
    [Authorize]
    public class VotosController : BaseController
    {
        internal override void CarregarViewBag()
        {
            ViewBag.IdRestaurante = new SelectList(db.Restaurantes.Where(r=>r.Ativo).OrderBy(r => r.Nome), "Id", "Nome");
        }
     
        // GET: Votos
        public ActionResult Index()
        {
            //ViewBag.Disabled = UsuarioAdministrador() ? "" : " disabled";
            List<VotoViewModel> votos = db.Votos.Include(v => v.Restaurante).OrderByDescending(v=>v.DataVoto).Select(v=> new VotoViewModel() { DataVoto  = v.DataVoto,Restaurante = v.Restaurante, Id = v.Id}).ToList();
            return View(votos);
        }

        // GET: Votos/Create
        public ActionResult Create()
        {
            CarregarViewBag();
            return View();
        }

        // POST: Votos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRestaurante")] Voto voto)
        {
            if (ModelState.IsValid)
            {
                var funcionario = FuncionarioRoles.ValidaFuncionario(db, UsuarioAtual.Username);
                string resultado = VoteRoles.Votar(db, funcionario.Id, voto.IdRestaurante, DateTimeNow);

                ModelState.AddModelError("",resultado);
                CarregarViewBag();
                return View(voto);
            }

            CarregarViewBag();
            return View(voto);
        }


        // GET: Votos/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Voto voto = db.Votos.Find(id);
        //    if (voto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(voto);
        //}
        // GET: Votos/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Voto voto = db.Votos.Find(id);
        //    if (voto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    CarregarViewBag();
        //    if (!UsuarioAdministrador())
        //    {
        //        ModelState.AddModelError("", "Usuário não possui permissão.");
        //        return View(voto);
        //    }

        //    return View(voto);
        //}

        // POST: Votos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,IdRestaurante,IdFuncionario,DataVoto")] Voto voto)
        //{
        //    if (!UsuarioAdministrador())
        //    {
        //        ModelState.AddModelError("", "Usuário não possui permissão.");
        //        return View(voto);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        if (!UsuarioAdministrador())
        //        {
        //            ModelState.AddModelError("", "Usuário não possui permissão.");
        //            CarregarViewBag();
        //            return View(voto);
        //        }
        //        db.Entry(voto).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(voto);
        //}

        // GET: Votos/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Voto voto = db.Votos.Find(id);
        //    if (voto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    CarregarViewBag();

        //    if (!UsuarioAdministrador())
        //    {
        //        ModelState.AddModelError("", "Usuário não possui permissão.");
        //        return View(voto);
        //    }
        //    return View(voto);
        //}

        // POST: Votos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{

        //    Voto voto = db.Votos.Find(id);
        //    if (!UsuarioAdministrador())
        //    {
        //        ModelState.AddModelError("", "Usuário não possui permissão.");
        //        CarregarViewBag();
        //        return View(voto);
        //    }
        //    db.Votos.Remove(voto);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
