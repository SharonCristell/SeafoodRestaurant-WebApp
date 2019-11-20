
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
    public class SucursalController : Controller
    {
        

        private RestauranteContext _context;
        public SucursalController(RestauranteContext c) {
            _context = c;
        }

        public IActionResult Index()
        {
            var sucursales = _context.Sucursales.Include(dis => dis.Distrito).ToList();
            ViewBag.s = sucursales;

            return View();
        }
        public IActionResult Registro()

        {
            ViewBag.Distritos = _context.Distritos.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Sucursal s)
        {
            if (ModelState.IsValid) {
                _context.Add(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Distritos = _context.Distritos.ToList();
            return View(s);
        }

    }
}