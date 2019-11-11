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
        [Display(Name="Distrito")]
        public string Distrito{get;set;}

        [Required]
        [Display(Name="Telefono")]
        public string Telefono{get;set;}

        [Required]
        [EmailAddress]
        [Display(Name="Correo Electrónico")]
        public string Correo{get;set;}

        
       


    }
}