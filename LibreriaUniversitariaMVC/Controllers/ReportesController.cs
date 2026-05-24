using System.Linq;
using System.Web.Mvc;
using LibreriaUniversitariaMVC.Data;
using LibreriaUniversitariaMVC.Models;

namespace LibreriaUniversitariaMVC.Controllers
{
    public class ReportesController : Controller
    {
        private readonly LibroDatos libroDatos = new LibroDatos();
        private readonly CategoriaDatos categoriaDatos = new CategoriaDatos();

        public ActionResult Index(string textoBusqueda, int? categoriaId)
        {
            if (Session["UsuarioNombre"] == null)
            {
                return RedirectToAction("Login", "Acceso");
            }

            var todosLosLibros = libroDatos.Listar();
            var librosFiltrados = todosLosLibros;

            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                string texto = textoBusqueda.Trim().ToLower();

                librosFiltrados = librosFiltrados
                    .Where(l => l.Titulo.ToLower().Contains(texto) || l.Autor.ToLower().Contains(texto))
                    .ToList();
            }

            if (categoriaId.HasValue && categoriaId.Value > 0)
            {
                librosFiltrados = librosFiltrados
                    .Where(l => l.CategoriaId == categoriaId.Value)
                    .ToList();
            }

            var reporte = new ReporteInventario
            {
                TextoBusqueda = textoBusqueda,
                CategoriaId = categoriaId ?? 0,
                LibrosFiltrados = librosFiltrados
                    .OrderBy(l => l.Titulo)
                    .ToList(),
                LibrosBajoStock = todosLosLibros
                    .Where(l => l.Stock <= 5)
                    .OrderBy(l => l.Stock)
                    .ThenBy(l => l.Titulo)
                    .ToList(),
                ResumenCategorias = todosLosLibros
                    .GroupBy(l => l.NombreCategoria)
                    .Select(g => new ResumenCategoria
                    {
                        Categoria = g.Key,
                        CantidadLibros = g.Count(),
                        StockTotal = g.Sum(l => l.Stock)
                    })
                    .OrderBy(r => r.Categoria)
                    .ToList(),
                TotalLibros = librosFiltrados.Count(),
                StockTotal = librosFiltrados.Sum(l => l.Stock),
                ValorInventarioTotal = librosFiltrados.Sum(l => l.Precio * l.Stock)
            };

            ViewBag.Categorias = new SelectList(categoriaDatos.Listar(), "CategoriaId", "Nombre", categoriaId);

            return View(reporte);
        }
    }
}
