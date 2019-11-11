using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nombre de categoría")]
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }   
    }
}