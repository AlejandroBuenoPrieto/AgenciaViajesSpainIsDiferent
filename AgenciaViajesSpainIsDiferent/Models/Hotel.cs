using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Hotel
    {
        [Key]
        //B
        // TODO: Agregar aquí la lógica del constructor
        //
        public int idHotel { get; set; }
        public string nombre { get; set; }
        public string calle { get; set; }
        public string provincia { get; set; }
        public string numerocalle { get; set; }
        public int codigopostal { get; set; }
        public string descripcion { get; set; }
        public string parking { get; set; }
        public int numeroestrellas { get; set; }
        public int numerohabitaciones { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}