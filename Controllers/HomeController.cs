using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoPM.Models;

namespace ProyectoPM.Controllers
{
    public class HomeController : Controller
    {
         private RestauranteContext _context;
        
        public HomeController(RestauranteContext c ) {
            this._context = c;
            
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Reserva()
        {
          var lista = _context.Sucursales.ToList();
            return View(lista);
            
           
        }

        public IActionResult Galeria()
        {
            return View();
        }
        
        

        public IActionResult Ubicanos()
        {
            var sucursales = _context.Sucursales.ToList();

            ViewBag.su = sucursales;

            return View();
        
        }

        public IActionResult Detalles(int id)
        {
          var producto = _context.Productos.Where(x=>x.Id==id).ToList();
          ViewBag.p = producto;
          
          return View();
        }
    }
}
