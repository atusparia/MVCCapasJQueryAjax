using System.ComponentModel.DataAnnotations;

namespace ExamenMVCCapas.Models
{
    public class AlumnoModel
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }        
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }        
        public string CorreoElectronico { get; set; }        
    }
}
