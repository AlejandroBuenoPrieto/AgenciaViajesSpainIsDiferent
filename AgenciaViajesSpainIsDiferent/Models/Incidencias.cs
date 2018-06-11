using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Incidencias
    {
        [Key]
        public int idIncidencia { get; set; }
        public string recurso { get; set; }
        public string compañia { get; set; }
        public string descripcion { get; set; }
    }
}