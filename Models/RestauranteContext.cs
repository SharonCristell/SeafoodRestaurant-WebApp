using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPM.Models
{
    public class RestauranteContext : IdentityDbContext
    {

        public DbSet<Usuario> Usuarios {get; set;}
        public RestauranteContext(DbContextOptions<RestauranteContext> o) : base(o){

        } 
    }
}