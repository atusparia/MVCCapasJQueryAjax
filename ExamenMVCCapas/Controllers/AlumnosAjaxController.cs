using ExamenMVCCapas.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MVCCapasJQueryAjax.Controllers
{
    public class AlumnosAjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
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

            return Json(model);
        }

        [HttpPost]
        public JsonResult Create(string nombre, string apellido, DateTime fechaNacimiento, string correoElectronico) 
        {
            var service= new AlumnoService();   
            service.Insert(new Domain.Alumno { Nombre = nombre, 
                Apellido=apellido, 
                FechaNacimiento= fechaNacimiento, 
                CorreoElectronico= correoElectronico, 
                Estado=true });

            return Json(new { message = "Formulario enviado con éxito. Gracias!" });
        }
    }
}
