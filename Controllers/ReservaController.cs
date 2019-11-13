using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoPM.Models;

namespace ProyectoPM.Controllers
{
    public class ReservaController : Controller
    {
         
        private RestauranteContext _context;
        private SignInManager<Usuario> _sim;
        private UserManager<Usuario> _um;
        private RoleManager<IdentityRole> _rm;

        public ReservaController(
            RestauranteContext c, 
            SignInManager<Usuario> s,
            UserManager<Usuario> um,
            RoleManager<IdentityRole> rm){
            _context = c;
            _sim = s;
            _um = um;
            _rm = rm;
        }
        public IActionResult Index(int tipo)
        {
            var distrito =_context.Distritos.OrderByDescending(x=>x.Id).ToList();
            var sucursales = _context.Sucursales.Where(x=> x.Nombre==null).OrderByDescending(x=>x.Id).ToList();              
             if(tipo!=0){
                    sucursales = _context.Sucursales.Where(x=>x.DistritoId==tipo).ToList();
                }

            ViewBag.s = sucursales;
            ViewBag.d =distrito;          
           
            return View();
        }

        public IActionResult Detalles(int id)
        {
          var sucursalSelecta = _context.Sucursales.Where(x=>x.Id==id).ToList();
          ViewBag.se = sucursalSelecta;
          
          return View();
        }

        public IActionResult Reservar(int id)
        {
            var user = _um.FindByNameAsync(User.Identity.Name).Result;
            var sucursal = _context.Sucursales.FirstOrDefault(x=> x.Id==id);
            var distrito = _context.Distritos.Where(x=>x.Id==sucursal.DistritoId).ToList();
            ViewBag.dis= distrito; 
            ViewBag.Id=id;    
          return View();
        }

        [HttpPost]
        public IActionResult Reservar(int id, Reserva r)
        {
            var user = _um.FindByNameAsync(User.Identity.Name).Result;
            var sucursal = _context.Sucursales.FirstOrDefault(x=> x.Id==id);
            var distrito = _context.Distritos.Where(x=>x.Id==sucursal.DistritoId).ToList();
            if(ModelState.IsValid){
                               
                    
                    r.Nombre=user.UserName;
                    _context.Add(r);
                    _context.SaveChanges();                   
                    
                    return RedirectToAction("Completado","Reservas");
                
                 
            }

            ViewBag.dis= distrito;         
            return View(); 
        }

        public IActionResult MisReservas()
        {
          var user = _um.FindByNameAsync(User.Identity.Name).Result;
          var reservas = _context.Reservas.Where(x=> x.Nombre==User.Identity.Name).ToList();           
          
          ViewBag.r = reservas;
          
          ViewBag.usuario = user.UserName;
          return View();
        }



    }
}