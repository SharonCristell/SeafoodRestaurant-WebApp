using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        
        [Required]
        [Display(Name="Nombre")]
        public string Nombre{get;set;}

        [Required]
        [Display(Name="Apellido")]
        public string Apellido{get;set;}

        [Required]
        [Display(Name="Celular")]
        public string Celular{get;set;}

        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string Email{get;set;}
        [Required]
        public int Mesa { get; set; }
        [Required]
        public String Fecha { get; set; }
        [Required]
        public int Horario { get; set; }
        [Required]
        [Display(Name="Descripcion")]
        public string Descripcion{get;set;}

        public Sucursal Sucursal { get; set; }
        public int SucursalId { get; set; }
    }
}