using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebParqueoUsuario.Models
{
    public class Usuarios
    {
        [Key]
        public int ID_Usuario { get; set; }

        public string Usuario { get; set; }

        public string Clave { get; set; }

        public int NivelUsuario { get; set; }
    }
}