using System.Web.Mvc;

namespace LibreriaUniversitariaMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            return View();
        }
    }
}
