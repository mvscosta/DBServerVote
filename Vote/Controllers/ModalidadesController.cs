using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vote.DAO;

namespace Vote.Controllers
{
    public class ModalidadesController : Controller
    {
        private VoteEF db = new VoteEF();

        // GET: Modalidades
        public ActionResult Index()
        {
            return View(db.Modalidades.ToList());
        }

        // GET: Modalidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidade modalidade = db.Modalidades.Find(id);
            if (modalidade == null)
            {
                return HttpNotFound();
            }
            return View(modalidade);
        }

        // GET: Modalidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modalidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Titulo")] Modalidade modalidade)
        {
            if (ModelState.IsValid)
            {
                db.Modalidades.Add(modalidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modalidade);
        }

        // GET: Modalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidade modalidade = db.Modalidades.Find(id);
            if (modalidade == null)
            {
                return HttpNotFound();
            }
            return View(modalidade);
        }

        // POST: Modalidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Titulo")] Modalidade modalidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modalidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modalidade);
        }

        // GET: Modalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modalidade modalidade = db.Modalidades.Find(id);
            if (modalidade == null)
            {
                return HttpNotFound();
            }
            return View(modalidade);
        }

        // POST: Modalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modalidade modalidade = db.Modalidades.Find(id);
            db.Modalidades.Remove(modalidade);
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
