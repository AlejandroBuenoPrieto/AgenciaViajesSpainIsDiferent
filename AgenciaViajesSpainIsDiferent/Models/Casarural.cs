using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Casarural
    {   [Key]
        public int idCasa { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public string provincia { get; set; }
        public string numerocalle { get; set; }
        public int codigopostal { get; set; }
        public string descripcion { get; set; }
        public string piscina { get; set; }
        public String actividades { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}