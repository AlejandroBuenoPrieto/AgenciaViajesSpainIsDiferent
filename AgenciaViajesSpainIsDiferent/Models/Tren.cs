using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Tren
    {
        [Key]
        public int trenid { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public string tipo { get; set; }
        public string cafeteria { get; set; }
        public string compania { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public int numeroplazas { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}