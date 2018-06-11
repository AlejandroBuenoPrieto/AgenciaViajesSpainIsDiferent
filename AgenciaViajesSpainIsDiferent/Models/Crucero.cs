using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Crucero
    {
        [Key]
        //B
        // TODO: Agregar aquí la lógica del constructor
        //
        public int idCrucero { get; set; }
        public string tipobarco { get; set; }
        public string compañia { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public int numeroplazas { get; set; }
        public string descripcion { get; set; }
        public int duracion { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}