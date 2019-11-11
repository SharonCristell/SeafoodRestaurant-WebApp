using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoPM.Models;

namespace ProyectoPM.Controllers
{
    //[Authorize(Roles="Administrador")]
    public class CategoriasController : Controller
    {
        private RestauranteContext _context;
        public CategoriasController(RestauranteContext c) {
            _context = c;
        }

        public IActionResult Index(int categoria)
        {
            var categorias =  _context.Categorias.OrderByDescending(x => x.Id).ToList();
            var productos = _context.Productos.Where(x => x.CategoriaId==categoria).OrderByDescending(x => x.Id).ToList();
            if (categoria!=0)
            {
                productos = _context.Productos.Where(x => x.CategoriaId==categoria).ToList();
            }
            ViewBag.p = productos;
            ViewBag.c = categorias;
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Categoria x)
        {
            if (ModelState.IsValid) {
                _context.Add(x);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(x);
        }
    }
}