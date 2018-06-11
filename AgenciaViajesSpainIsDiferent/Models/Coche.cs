using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Coche
    { [Key]
        public int idCoche{ get; set; }
        public string seguro { get; set; }
        public string sillaniños{ get; set; }
        public int opcionsilla { get; set; }
        public string compañia { get; set; }
        public string calle { get; set; }
        public string provincia { get; set; }
        public string numerocalle { get; set; }
        public int codigopostal { get; set; }
        public int numerocoches { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}