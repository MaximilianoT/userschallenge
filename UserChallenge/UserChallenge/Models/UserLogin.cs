using System.ComponentModel.DataAnnotations;

namespace UserChallenge.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "El nombre de usuario es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario debe ser mayor a 1 caracter y menor a 50 caracteres.")]
        [Display(Name = "Username")]
        public  string _username { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "Contraseña inválida. Debe ser mayor a 0 y menor a 50 caracteres.")]
        [DataType(DataType.Password)]
        public  string _password { get; set; }
    }
}
