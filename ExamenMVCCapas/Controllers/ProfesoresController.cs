using Domain;
using ExamenMVCCapas.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ExamenMVCCapas.Controllers
{
    public class ProfesoresController : Controller
    {
        public IActionResult Index()
        {
            ProfesorService service = new ProfesorService();

            var profesores = service.Get();

            var model = profesores.Select(x => new ProfesorModel
            {
                ProfesorID = x.ProfesorID,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Especialidad = x.Especialidad,
                CorreoElectronico = x.CorreoElectronico                
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nombre, Apellido, Especialidad, CorreoElectronico")] ProfesorModel model)
        {
            if (ModelState.IsValid)
            {
                ProfesorService service = new ProfesorService();

                var dominio = new Profesor
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Especialidad = model.Especialidad,
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
