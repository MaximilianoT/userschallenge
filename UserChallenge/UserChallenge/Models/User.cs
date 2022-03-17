using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserChallenge.Models
{
    public class User
    {
        [Key]
        public int IdUsuario { get; }

        [Required(ErrorMessage = "El nombre de usuario es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario debe ser mayor a 1 caracter y menor a 50 caracteres.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario debe ser mayor a 1 caracter y menor a 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario debe ser mayor a 1 caracter y menor a 50 caracteres.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
       
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        
    }
}
