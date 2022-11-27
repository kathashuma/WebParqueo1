using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParqueo.Models
{
    public class Ajustes
    {
        [Key]
        public int ID_Ajustes { get; set; }

        public string NombreParqueo { get; set; }

        public string CantidadParqueo { get; set; }

    }
}