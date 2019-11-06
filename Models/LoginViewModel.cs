using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name="Correo Electrónico")]
        public string Correo{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Contraseña")]
        public string Password{get;set;}

    }
}