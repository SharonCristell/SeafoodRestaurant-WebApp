using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class Distrito
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nombre")]
        public string Nombre { get; set; }
        public List<Sucursal> Sucursales { get; set; }   
    }
}