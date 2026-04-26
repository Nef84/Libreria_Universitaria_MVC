using System.Data.SqlClient;
using System.Net;
using System.Web.Mvc;
using LibreriaUniversitariaMVC.Data;
using LibreriaUniversitariaMVC.Models;

namespace LibreriaUniversitariaMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly CategoriaDatos datos = new CategoriaDatos();

        public ActionResult Index()
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            return View(datos.Listar());
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

            Categoria categoria = datos.ObtenerPorId(id.Value);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        public ActionResult Create()
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaId,Nombre,Descripcion")] Categoria categoria)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            datos.Insertar(categoria);
            TempData["Mensaje"] = "Categoria guardada correctamente.";
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

            Categoria categoria = datos.ObtenerPorId(id.Value);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,Nombre,Descripcion")] Categoria categoria)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            datos.Actualizar(categoria);
            TempData["Mensaje"] = "Categoria actualizada correctamente.";
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

            Categoria categoria = datos.ObtenerPorId(id.Value);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
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

            try
            {
                datos.Eliminar(id);
                TempData["Mensaje"] = "Categoria eliminada correctamente.";
            }
            catch (SqlException)
            {
                TempData["Error"] = "No se puede eliminar la categoria porque tiene libros asociados.";
            }

            return RedirectToAction("Index");
        }
    }
}
