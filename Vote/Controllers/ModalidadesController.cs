using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;
using Vote.DAO;
using Vote.ViewModels;

namespace Vote.Controllers
{
    [Authorize]
    public class ModalidadesController : BaseController
    {
        private IModalidadeDataAccess _modalidadeDataAccess { get; set; }

        public ModalidadesController(IModalidadeDataAccess modalidadeDataAccess)
        {
            this._modalidadeDataAccess = modalidadeDataAccess;
        }

        internal override void CarregarViewBag()
        {
            ViewBag.Disabled = UsuarioAdministrador() ? "" : " disabled";
        }

        // GET: Modalidades
        public ActionResult Index()
        {
            CarregarViewBag();
            return View(this._modalidadeDataAccess.All.OrderBy(m=>m.Titulo).ToList());
        }

        // GET: Modalidades/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IModalidade modalidade = this._modalidadeDataAccess.Find(id.Value);

            if (modalidade == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // GET: Modalidades/Create
        public ActionResult Create()
        {
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View();
            }
            return View();
        }

        // POST: Modalidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModalidadeViewModel modalidade)
        {
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<ModalidadeViewModel>(modalidade));
            }
            if (ModelState.IsValid)
            {
                this._modalidadeDataAccess.Add(Mapper.Map<Modalidade>(modalidade));
                return RedirectToAction("Index");
            }

            return View(Mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // GET: Modalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IModalidade modalidade = this._modalidadeDataAccess.Find(id.Value);

            if (modalidade == null)
            {
                return HttpNotFound();
            }
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<ModalidadeViewModel>(modalidade));
            }
            return View(Mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // POST: Modalidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModalidadeViewModel modalidade)
        {
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<ModalidadeViewModel>(modalidade));
            }
            if (ModelState.IsValid)
            {
                this._modalidadeDataAccess.Edit(Mapper.Map<Modalidade>(modalidade));

                return RedirectToAction("Index");
            }
            return View(Mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // GET: Modalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IModalidade modalidade = this._modalidadeDataAccess.Find(id.Value);

            if (modalidade == null)
            {
                return HttpNotFound();
            }
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<ModalidadeViewModel>(modalidade));
            }
            return View(Mapper.Map<ModalidadeViewModel>(modalidade));
        }

        // POST: Modalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IModalidade modalidade = this._modalidadeDataAccess.Find(id);

            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<ModalidadeViewModel>(modalidade));
            }

            this._modalidadeDataAccess.Remove(modalidade);
            return RedirectToAction("Index");
        }

    }
}
