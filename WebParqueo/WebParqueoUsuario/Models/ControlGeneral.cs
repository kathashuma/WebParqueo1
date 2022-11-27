using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParqueoUsuario.Models
{
    public class ControlGeneral
    {
        [Key]
        public int ID_Control { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Placa { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
    }
}