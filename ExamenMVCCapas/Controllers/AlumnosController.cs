using Domain;
using ExamenMVCCapas.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ExamenMVCCapas.Controllers
{
    public class AlumnosController : Controller
    {
        public IActionResult Index()
        {
            AlumnoService service = new AlumnoService();

            var alumnos = service.Get();

            var model = alumnos.Select(x => new AlumnoModel
            {
                AlumnoId = x.AlumnoId,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                FechaNacimiento = x.FechaNacimiento,
                CorreoElectronico = x.CorreoElectronico
            }).ToList();

            return View(model);
        }

        public IActionResult IndexAjax() 
        { 
            return View();
        }

        //public IActionResult GetAjax()
        public IActionResult GetAjax(string filter)
        {
            AlumnoService service = new AlumnoService();

            //Listado de alumnos de DOMAIN
            
            var alumnos = service.GetFilter(filter);
            //var alumnos = service.Get();

            var model = alumnos.Select(x => new AlumnoModel
            {
                AlumnoId= x.AlumnoId,
                Nombre= x.Nombre,
                Apellido= x.Apellido,
                FechaNacimiento = x.FechaNacimiento,
                CorreoElectronico= x.CorreoElectronico
            }).ToList();

            return Json(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nombre, Apellido, FechaNacimiento, CorreoElectronico")] AlumnoModel model)
        {
            if (ModelState.IsValid)
            {
                AlumnoService service = new AlumnoService();

                var dominio = new Alumno
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    FechaNacimiento = model.FechaNacimiento,
                    CorreoElectronico = model.CorreoElectronico,
                    Estado = true                    
                };

                service.Insert(dominio);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
