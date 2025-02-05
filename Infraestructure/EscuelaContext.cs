using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   /*
            optionsBuilder.UseSqlServer("data source = SRVMIO;" +
                    "initial catalog=EscuelaMVCCapasDB; User Id=usMio; Pwd=Rcm123456;" +
                    "TrustServerCertificate=true");
            */

            optionsBuilder.UseSqlServer("data source = UEI11B;" +
                    "initial catalog=EscuelaMVCCapasDB; User Id=sa; Pwd=Hrm260381;" +
                    "TrustServerCertificate=true");
        }
    }
}
