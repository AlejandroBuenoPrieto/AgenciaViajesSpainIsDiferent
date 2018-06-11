using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Vuelo
    {
        [Key]
        //B
        // TODO: Agregar aquí la lógica del constructor
        //
        public int idVuelo { get; set; }
        public string lowcost { get; set; }
        public string compañia { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public int numeroplazas { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}