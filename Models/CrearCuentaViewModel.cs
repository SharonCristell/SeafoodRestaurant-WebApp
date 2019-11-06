using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class CrearCuentaViewModel
    {
        [Required]
        [Display(Name="Nombre")]
        public string Nombre{get;set;}

        [Required]
        [Display(Name="Apellido")]
        public string Apellido{get;set;}

        [Required]
        [Display(Name="Genero")]
        public string Genero{get;set;}

        [Required]
        [EmailAddress]
        [Display(Name="Correo Electrónico")]
        public string Correo{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Contraseña")]
        public string Password1{get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirmar Contraseña")]
        [Compare("Password1",ErrorMessage="Las contraseñas no coinciden")]
        public string Password2{get;set;}
    }
}