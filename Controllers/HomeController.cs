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

        

        public IActionResult Reserva(string distrito)
        {
                              
            var sucursal = _context.Sucursales.Where(x=> x.Nombre!=null).OrderByDescending(x=>x.Id).ToList();              
                 if(distrito!="" && distrito!=null){
                    sucursal = sucursal.Where(x=>x.Distrito==distrito).ToList();
                }              
            ViewBag.s = sucursal;
           
            return View();
        
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
    }
}
