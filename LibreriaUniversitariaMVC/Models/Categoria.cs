using System.ComponentModel.DataAnnotations;

namespace LibreriaUniversitariaMVC.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener mas de 100 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(255, ErrorMessage = "La descripcion no puede tener mas de 255 caracteres.")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
    }
}
