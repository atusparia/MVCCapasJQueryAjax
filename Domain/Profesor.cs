using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Profesor
    {
        public int ProfesorID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        [EmailAddress]
        public string CorreoElectronico { get; set; }
        public bool Estado { get; set; }
    }
}
