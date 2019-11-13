namespace ProyectoPM.Models
{
    public class PedidoProducto
    {
        public int Int { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProd { get; set; }        
        public int Monto { get; set; }
    }
}