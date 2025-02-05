﻿using System.ComponentModel.DataAnnotations;

namespace ExamenMVCCapas.Models
{
    public class ProfesorModel
    {
        public int ProfesorID { get; set; }       
        public string Nombre { get; set; }       
        public string Apellido { get; set; }
        public string Especialidad { get; set; }       
        public string CorreoElectronico { get; set; }       
    }
}
