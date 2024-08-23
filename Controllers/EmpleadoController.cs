using EjemploASP.Data;
using EjemploASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Empleado = _context.Empleado.ToList();  //Viewbag Objeto dinamico
            ViewBag.TipoEmpleado = _context.TipoEmpleado.ToList();
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
        public IActionResult EnviarFormulario(
            string nombre,string apellido,string dui,string numeroTelefonico, int tipoEmpleadoID)  
        {
            var empleado = new Empleado
            {
                Nombre = nombre,
                Apellido = apellido,
                NumeroTelefonico = numeroTelefonico,
                Dui = dui,
                TipoEmpleadoId = tipoEmpleadoID

            };
            _context.Empleado.Add(empleado);
            _context.SaveChanges();           
            Thread.Sleep(2000);
            // Redirigir a la vista Index para mostrar la lista actualizada de empleados
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            var empleado = _context.Empleado.FirstOrDefault(e => e.Id == id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult EditarEmpleado(Empleado empleado)
        {
            var empleadoExistente = _context.Empleado.Find(empleado.Id);
            if (empleadoExistente != null)
            {
                empleadoExistente.Nombre = empleado.Nombre;
                empleadoExistente.Apellido = empleado.Apellido;
                empleadoExistente.NumeroTelefonico = empleado.NumeroTelefonico;
                empleadoExistente.Dui = empleado.Dui;

                _context.SaveChanges();
                TempData["AddSuccess"] = true;
                Thread.Sleep(2000);
                return RedirectToAction("Index");
            }

            TempData["AddSuccess"] = false;
            return View(empleado);
        }

    }
}
