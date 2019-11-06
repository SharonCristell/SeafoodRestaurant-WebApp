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

        public CuentaController(RestauranteContext c, SignInManager<Usuario> s,UserManager<Usuario> um){
            _context = c;
            _sim = s;
            _um = um;
        }

        public IActionResult Crear(){
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario model){
            if(ModelState.IsValid){
                var usuario = new Usuario();
                usuario.Nombre =model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.Genero = model.Genero;
                usuario.Correo = model.Correo;

                IdentityResult resultado = _um.CreateAsync(usuario,model.Password1).Result;

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
        
    }
}