using System.ComponentModel.DataAnnotations;

namespace LibreriaUniversitariaMVC.Models
{
    public class LoginUsuario
    {
        [Required(ErrorMessage = "Debes ingresar el usuario.")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Debes ingresar la contraseña.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}
