using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }
        public DateTime Fecha { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public float Precio { get; set; }
        public Producto() {
            Fecha = DateTime.Now;
        }
    }
}