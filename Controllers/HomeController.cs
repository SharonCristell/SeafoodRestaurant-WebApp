using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Nosotros()
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
            var sucursales = _context.Sucursales.Include(dis => dis.Distrito).ToList();
            ViewBag.s = sucursales;

            return View();
        
        }

        
    }
}
