using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebParqueo.Models
{
    public class Conexion
    {
        public static string StrConecta = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();   
    }
}