using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class CambiarContraseñaViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string ContrasenaActual { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ContrasenaNueva { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("ContrasenaNueva", ErrorMessage = "Las contraseñas no coinciden")]
        public string ContrasenaConfirmacion { get; set; }
    }
}