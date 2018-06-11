using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgenciaViajesSpainIsDiferent.Models
{
    public class Excursiones
    {
        [Key]

        public int ExcursionId { get; set; }
        public string nombreExcursion { get; set; }
        public string ciudad { get; set; }
        public string tipo { get; set; }
    }
}