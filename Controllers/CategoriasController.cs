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

        public IActionResult Index()
        {
            var lista = _context.Categorias.ToList();
            return View(lista);
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