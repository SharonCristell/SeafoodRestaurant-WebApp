using System;
using System.Collections.Generic;

namespace ProyectoPM.Models
{
    public class Pedido
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public Producto Producto { get; set; }
        public int ProductoId { get; set; } 
        public int Cantidad { get; set; } 
        public Double MontoTotal { get; set; }
    }
}