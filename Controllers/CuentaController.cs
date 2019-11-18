using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoPM.Models;

namespace ProyectoPM.Controllers
{
    public class CuentaController : Controller
    {
        private RestauranteContext _context;
        private SignInManager<Usuario> _sim;
        private UserManager<Usuario> _um;
        private RoleManager<IdentityRole> _rm;

        public CuentaController(
            RestauranteContext c, 
            SignInManager<Usuario> s,
            UserManager<Usuario> um,
            RoleManager<IdentityRole> rm){
            _context = c;
            _sim = s;
            _um = um;
            _rm = rm;
        } 

        public IActionResult AsociarRol(){
            ViewBag.Usuarios = _um.Users.ToList();
            ViewBag.Roles = _rm.Roles.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AsociarRol(string usuario,string rol){
            var user = _um.FindByIdAsync(usuario).Result;

            var resultado = _um.AddToRoleAsync(user,rol).Result;

            return RedirectToAction("index","home");
        }

        public IActionResult CrearRol(){
            return View();
        }

        [HttpPost]
        public IActionResult CrearRol(string nombre){
            var rol = new IdentityRole();
            rol.Name = nombre;

            var resultado = _rm.CreateAsync(rol).Result;
            
            return RedirectToAction("index","home");
        }

        public IActionResult Crear(){
            return View();
        }

        public IActionResult AccesoDenegado(){
            return View();
        }

        
        [HttpPost]
        public IActionResult Crear(Usuario model){
            if(ModelState.IsValid){
                var usuario = new Usuario();
                
                usuario.Nombre =model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.Genero = model.Genero;
                usuario.UserName = model.Correo;
                usuario.Email = model.Correo;

                IdentityResult resultado = _um.CreateAsync(usuario,model.Password1).Result;
                //var r = _um.AddToRoleAsync(usuario, "Usuario").Result;
                
                if(resultado.Succeeded){
                    return RedirectToAction("index","home");
                }
                else{
                    foreach (var item in resultado.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model){
            if(ModelState.IsValid){
                var resultado = _sim.PasswordSignInAsync(model.Correo,model.Password,true,false).Result;
                if(resultado.Succeeded){
                    return RedirectToAction("index","home");
                }
                else{
                    ModelState.AddModelError("","Datos Incorrectos");
                }
            }
            return View(model);
        }

        public IActionResult Logout(){
            _sim.SignOutAsync();
            return RedirectToAction("index","home");
        }

        public IActionResult HistorialUsuario()
        {
          var user = _um.FindByNameAsync(User.Identity.Name).Result;
          var reservas = _context.Reservas.Where(x=> x.UserName==User.Identity.Name).ToList();           
          ViewBag.r = reservas;
          ViewBag.usuario = user.UserName;
          return View();
        }
        
        public IActionResult RealizarPedido(int idProduct, int cantidad){
            var user = _um.FindByNameAsync(User.Identity.Name).Result;
            var producto = _context.Productos.FirstOrDefault(x => x.Id==idProduct);
            var categoria = _context.Categorias.Where(x => x.Id==producto.CategoriaId);

            ViewBag.precio = producto;
            ViewBag.categoria = categoria;
            ViewBag.idProduct = idProduct;
            ViewBag.cantidad = cantidad;

            return View();
        }
        [HttpPost]
        public IActionResult RealizarPedido(int idProduct, int cantidad, Compras compras){
            var user = _um.FindByIdAsync(User.Identity.Name).Result;
            var producto = _context.Productos.FirstOrDefault(x => x.Id==idProduct);
            var categoria = _context.Categorias.Where(x => x.Id==producto.CategoriaId);
            if (ModelState.IsValid)
            {
                compras.IdCliente = user.Id;
                compras.IdProduct = producto.Id;
                compras.Cantidad = cantidad;
                compras.TotalMonto = cantidad * producto.Precio;
                _context.Add(compras);
                _context.SaveChanges();
                HttpContext.Session.SetString("valida", "Adopcion tramitada con exito");
                return RedirectToAction("Index", "Home");
            } 

            ViewBag.Precio = producto;
            ViewBag.categoria = categoria;
            ViewBag.idProduct = idProduct;
            ViewBag.cantidad = cantidad;

            return View();
        }
    }
}