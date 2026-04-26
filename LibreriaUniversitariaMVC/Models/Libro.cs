using System.ComponentModel.DataAnnotations;

namespace LibreriaUniversitariaMVC.Models
{
    public class Libro
    {
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio.")]
        [StringLength(200, ErrorMessage = "El titulo no puede tener mas de 200 caracteres.")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(150, ErrorMessage = "El autor no puede tener mas de 150 caracteres.")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(typeof(decimal), "0.01", "99999", ErrorMessage = "Ingrese un precio valido.")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, 1000, ErrorMessage = "El stock debe ser un numero entre 0 y 1000.")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una categoria.")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public string NombreCategoria { get; set; }
    }
}
