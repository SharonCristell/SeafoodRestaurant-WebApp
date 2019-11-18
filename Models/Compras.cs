using System.ComponentModel.DataAnnotations;

namespace ProyectoPM.Models
{
    public class Compras
    {
        [Key]
        public int IdCompra { get; set; }
        public string UserName{ get; set; }
        public int Cantidad { get; set; }
        public double TotalMonto { get; set; }
        [Required]
        public string Nombres{ get; set; }
        [Required]
        public string Apellidos{ get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string NumeroCuenta { get; set; }
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
    }
}