using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPM.Models
{
    public class RestauranteContext : IdentityDbContext
    {

        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Producto> Productos {get; set;}

        public DbSet<Reserva> Reservas {get; set;}

        public DbSet<Sucursal> Sucursales { get; set; } 

        public DbSet<Distrito> Distritos { get; set; }   
        public DbSet<Pedido> Pedidos { get; set; }   
        public DbSet<Compras> Compras { get; set;}
        public RestauranteContext(DbContextOptions<RestauranteContext> o) : base(o){

        } 
    }
}