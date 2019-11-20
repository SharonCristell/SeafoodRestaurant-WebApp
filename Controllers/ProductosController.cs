using System.IO;
using System.Linq;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPM.Models;

namespace ProyectoPM.Controllers
{
    public class ProductosController : Controller
    {
        private RestauranteContext _context;
        public ProductosController(RestauranteContext c) {
            _context = c;
        }
        public IActionResult Index()
        {
            var lista = _context.Productos.ToList();
            return View(lista);
        }
        public IActionResult Registro()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Producto x)
        {
            if (ModelState.IsValid) {

                
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = _context.Categorias.ToList();
            return View(x);
        }
        public IActionResult Detalle(int id)
        {
          var producto = _context.Productos.Where(x=>x.Id==id).ToList();
          ViewBag.pE = producto;
          
          return View();
        }
        public IActionResult ComprasRealizadas(){
            var usuarios = _context.Usuarios.ToList();
            var compras = _context.Compras.Include(p => p.Producto).ToList();

            ViewBag.compras = compras;
            ViewBag.usuarios = usuarios;

            return View();
        }
    }
}