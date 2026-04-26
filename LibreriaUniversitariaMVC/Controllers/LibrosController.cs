using System.Net;
using System.Web.Mvc;
using LibreriaUniversitariaMVC.Data;
using LibreriaUniversitariaMVC.Models;

namespace LibreriaUniversitariaMVC.Controllers
{
    public class LibrosController : Controller
    {
        private readonly LibroDatos libroDatos = new LibroDatos();
        private readonly CategoriaDatos categoriaDatos = new CategoriaDatos();

        public ActionResult Index()
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            return View(libroDatos.Listar());
        }

        public ActionResult Details(int? id)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Libro libro = libroDatos.ObtenerPorId(id.Value);

            if (libro == null)
            {
                return HttpNotFound();
            }

            return View(libro);
        }

        public ActionResult Create()
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            CargarCategorias();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibroId,Titulo,Autor,Precio,Stock,CategoriaId")] Libro libro)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (!ModelState.IsValid)
            {
                CargarCategorias(libro.CategoriaId);
                return View(libro);
            }

            libroDatos.Insertar(libro);
            TempData["Mensaje"] = "Libro guardado correctamente.";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Libro libro = libroDatos.ObtenerPorId(id.Value);

            if (libro == null)
            {
                return HttpNotFound();
            }

            CargarCategorias(libro.CategoriaId);
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibroId,Titulo,Autor,Precio,Stock,CategoriaId")] Libro libro)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (!ModelState.IsValid)
            {
                CargarCategorias(libro.CategoriaId);
                return View(libro);
            }

            libroDatos.Actualizar(libro);
            TempData["Mensaje"] = "Libro actualizado correctamente.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Libro libro = libroDatos.ObtenerPorId(id.Value);

            if (libro == null)
            {
                return HttpNotFound();
            }

            return View(libro);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            libroDatos.Eliminar(id);
            TempData["Mensaje"] = "Libro eliminado correctamente.";
            return RedirectToAction("Index");
        }

        private void CargarCategorias(int categoriaId = 0)
        {
            ViewBag.Categorias = new SelectList(categoriaDatos.Listar(), "CategoriaId", "Nombre", categoriaId);
        }
    }
}
