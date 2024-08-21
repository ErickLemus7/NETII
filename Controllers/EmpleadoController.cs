using EjemploASP.Data;
using EjemploASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjemploASP.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBcontext _context; //Recomendacion de microsoft variable privada inicia con _


        public EmpleadoController(ILogger<HomeController> logger,
            ApplicationDBcontext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()

        {
            ViewBag.Empleado = _context.Empleado.ToList();  //Que es viewBag 
            return View();
        }

        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult EnviarFormulario(string nombre, string email)
        {
            // 

            // Redirigir a una vista de confirmación o mostrar un mensaje
            ViewBag.Mensaje = $"Gracias {nombre}, tu formulario ha sido enviado correctamente.";
            return View("Confirmacion");
        }
    }
}
