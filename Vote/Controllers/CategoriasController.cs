using AutoMapper;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;
using Vote.ViewModels;

namespace Vote.Controllers
{
    [Authorize]
    public class CategoriasController : BaseController
    {
        private ICategoriaDataAccess _categoriaDataAccess { get; set; }

        public CategoriasController(ICategoriaDataAccess categoriaDataAccess)
        {
            this._categoriaDataAccess = categoriaDataAccess;
        }

        internal override void CarregarViewBag()
        {
            ViewBag.Disabled = UsuarioAdministrador() ? "" : " disabled";
        }

        // GET: Categorias
        public ActionResult Index()
        {
            CarregarViewBag();
            return View(this._categoriaDataAccess.All.OrderBy(c=>c.Titulo).ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = this._categoriaDataAccess.All.First(c => c.Id == id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<CategoriaViewModel>(categoria));
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View();
            }
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoria)
        {
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(categoria);
            }
            if (ModelState.IsValid)
            {
                this._categoriaDataAccess.Add(Mapper.Map<DAO.Categoria>(categoria));
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ICategoria categoria = this._categoriaDataAccess.Find(id.Value);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<CategoriaViewModel>(categoria));
            }
            return View(Mapper.Map<CategoriaViewModel>(categoria));
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel categoria)
        {
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<CategoriaViewModel>(categoria));
            }
            if (ModelState.IsValid)
            {
                this._categoriaDataAccess.Edit(Mapper.Map<DAO.Categoria>(categoria));
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ICategoria categoria = this._categoriaDataAccess.Find(id.Value);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(categoria);
            }
            return View(Mapper.Map<CategoriaViewModel>(categoria));
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ICategoria categoria = this._categoriaDataAccess.Find(id);

            if (!UsuarioAdministrador())
            {
                ModelState.AddModelError("", "Usuário não possui permissão.");
                return View(Mapper.Map<CategoriaViewModel>(categoria));
            }

            this._categoriaDataAccess.Remove(categoria);

            return RedirectToAction("Index");
        }
    }
}
