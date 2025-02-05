using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProfesorService
    {
        public List<Profesor> Get()
        {
            using (var context = new EscuelaContext())
            {
                return context.Profesores.Where(x => x.Estado == true).ToList();
                //return context.Profesores.ToList();
            }
        }

        public void Insert(Profesor profesor)
        {
            using (var context = new EscuelaContext())
            {
                context.Profesores.Add(profesor);
                context.SaveChanges();
            }
        }
               
    }
}
