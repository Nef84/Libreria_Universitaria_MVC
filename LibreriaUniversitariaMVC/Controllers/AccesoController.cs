using System.Web.Mvc;
using LibreriaUniversitariaMVC.Data;
using LibreriaUniversitariaMVC.Models;

namespace LibreriaUniversitariaMVC.Controllers
{
    public class AccesoController : Controller
    {
        private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();

        public ActionResult Login()
        {
            if (Session["UsuarioNombre"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUsuario login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            UsuarioSesion usuario = usuarioDatos.ValidarUsuario(login.NombreUsuario, login.Contrasena);

            if (usuario == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View(login);
            }

            Session["UsuarioID"] = usuario.UsuarioId;
            Session["UsuarioLogin"] = usuario.NombreUsuario;
            Session["UsuarioNombre"] = usuario.Nombre;
            Session["UsuarioRol"] = usuario.Rol;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
