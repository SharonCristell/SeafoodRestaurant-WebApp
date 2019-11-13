using System;

namespace ProyectoPM.Models
{
    public class PedidoProducto
    {
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProd { get; set; }        
        public Double MontoProd { get; set; }
    }
}