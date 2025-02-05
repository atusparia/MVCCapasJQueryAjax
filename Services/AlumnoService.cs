using Domain;
using Infraestructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AlumnoService
    {
        public List<Alumno> Get()
        {
            using (var context = new EscuelaContext())
            {
                return context.Alumnos.Where(x => x.Estado == true).ToList();
                //return context.Alumnos.ToList();
            }
        }

        public List<Alumno> GetFilter(string filter)
        {
            using (var context = new EscuelaContext())
            {
                var query = context.Alumnos.Where(x=>x.Estado==true);

                if(!filter.IsNullOrEmpty())
                    query = query.Where(x=>x.Nombre.Contains(filter));
                
                return query.ToList();
            }
        }

        public void Insert(Alumno alumno)
        {
            using (var context = new EscuelaContext())
            {
                context.Alumnos.Add(alumno);
                context.SaveChanges();
            }
        }
    }
}
