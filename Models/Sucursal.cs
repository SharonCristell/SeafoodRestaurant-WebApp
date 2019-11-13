using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class Sucursal
    {
       
       public int Id { get; set; }
     

        [Required]
        [Display(Name="Nombre")]
        public string Nombre{get;set;}

        [Required]
        [Display(Name="Direccion")]
        public string Direccion{get;set;}
         
        [Required]
        [Display(Name="Foto")]
        public string Foto { get; set; }

        [Required]
        [Display(Name="Telefono")]
        public string Telefono{get;set;}

        [Required]
        [EmailAddress]
        [Display(Name="Correo Electrónico")]
        public string Correo{get;set;}

        [Required]
        [Display(Name="DireccionMaps")]
        public string DireccionMaps{get;set;}

        public Distrito Distrito { get; set; }
        public int DistritoId { get; set; }

        public List<Reserva> Reservas { get; set; }   
      
    }
}