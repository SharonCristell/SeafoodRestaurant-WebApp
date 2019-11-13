using System;
using System.Collections.Generic;

namespace ProyectoPM.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<PedidoProducto> PedidosProductos { get; set; }  
        public Double MontoTotal { get; set; }
    }
}