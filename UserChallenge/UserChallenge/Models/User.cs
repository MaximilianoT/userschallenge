using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserChallenge.Models
{
    [Table("Usuarios")]
    public class User
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario debe ser mayor a 1 caracter y menor a 50 caracteres.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El Nombre es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario debe ser mayor a 1 caracter y menor a 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Email es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario debe ser mayor a 1 caracter y menor a 50 caracteres.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
       
        public string Email { get; set; }

        [Column("Telefono")]
        [Required(ErrorMessage = "El Telefono es un campo obligatorio.")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "Contraseña inválida. Debe ser mayor a 0 y menor a 50 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
