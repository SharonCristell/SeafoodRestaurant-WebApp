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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Carta()
        {
            return View();
        }

        public IActionResult Reserva()
        {
            return View();
        }

        public IActionResult Galeria()
        {
            return View();
        }

        public IActionResult Ubicanos()
        {
            return View();
        }
    }
}
