using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebParqueo.Models;
using WebParqueo.Permisos;

namespace WebParqueo.Controllers
{
    [ValidarSesion]
    public class AjustesController : Controller
    {
        public static List<Ajustes> alista = new List<Ajustes>();
        // GET: Clientes

        #region Metodos Get paginas/views

        public ActionResult Inicio()
        {
            alista.Clear();
            //ADO.net
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                //Se llama al SP para listar
                SqlCommand cmd = new SqlCommand("SP_ListarAjustes", cone);
                cmd.CommandType = CommandType.Text;
                cone.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Ajustes oAjustes = new Ajustes();    // se instancia la clase cliente para llenarla de datos
                        oAjustes.ID_Ajustes = Convert.ToInt32(dr["ID_Ajustes"]);
                        oAjustes.NombreParqueo = (dr["NombreParqueo"].ToString());
                        oAjustes.CantidadParqueo = (dr["CantidadParqueo"].ToString());
                        
                        alista.Add(oAjustes); //se van agregando los datos a olista
                    }
                }
            }
            return View(alista); // se mandan todos los valores a la lista
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction("Inicio", "Ajustes");
            }
            Ajustes oAjustes = alista.Where(c => c.ID_Ajustes == ID).FirstOrDefault();
            return View(oAjustes);
        }

        [HttpGet]
        public ActionResult Eliminar(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction("Inicio", "Ajustes");
            }
            Ajustes oAjustes = alista.Where(c => c.ID_Ajustes == ID).FirstOrDefault();
            return View(oAjustes);
        }

        #endregion
        // Fin de los metodos GET para paginas/views

        #region Metodos Post de las views

        [HttpPost]
        public ActionResult Registrar(Ajustes oAjustes)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarAjustes", cone);
                cmd.Parameters.AddWithValue("NombreParqueo", oAjustes.NombreParqueo);
                cmd.Parameters.AddWithValue("CantidadParqueo", oAjustes.CantidadParqueo);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Ajustes");
        }

        [HttpPost]
        public ActionResult Editar(Ajustes oAjustes)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EditarAjustes", cone);
                cmd.Parameters.AddWithValue("ID_Ajustes", oAjustes.ID_Ajustes);
                cmd.Parameters.AddWithValue("NombreParqueo", oAjustes.NombreParqueo);
                cmd.Parameters.AddWithValue("CantidadParqueo", oAjustes.CantidadParqueo);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Ajustes");
        }

        [HttpPost]
        public ActionResult Eliminar(string ID)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarAjustes", oconexion);
                cmd.Parameters.AddWithValue("ID_Ajustes", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Ajustes");
        }

        #endregion

    }
}