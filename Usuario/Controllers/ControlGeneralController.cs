using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebParqueoUsuario.Models;
using WebParqueo.Permisos;

namespace WebParqueoUsuario.Controllers
{
    [ValidarSesion]
    public class ControlGeneralController : Controller
    {
        // Variable para Crear una Lista de Cliente
        public static List<ControlGeneral> olista = new List<ControlGeneral>();

        #region Todos los metodos Get para llamar las View
        #region MetodoGETPaginaInicio
        public ActionResult Inicio()
        {
            olista.Clear(); // Borramos la lista para que no quede nada en memoria.

            using (SqlConnection oconexion = new SqlConnection(Conexion.StrConecta))
            {
                // Se llama al Store porcedure para listar.
                SqlCommand cmd = new SqlCommand("SP_ListarControlGeneral", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ControlGeneral control = new ControlGeneral(); //  Instancia de la Clase 
                        control.ID_Control = Convert.ToInt32(dr["ID_Control"]);
                        control.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                        control.Hora = dr["Hora"].ToString();
                        control.Placa = dr["Placa"].ToString();
                        control.Tipo = dr["Tipo"].ToString();
                        control.Estado = dr["Estado"].ToString();
                        control.Usuario = dr["Usuario"].ToString();

                        olista.Add(control);
                    }
                }
            }

            return View(olista);
        }
        #endregion

        #region MetodoGETPaginaRegistrar
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }
        #endregion

        #region MetodoGETPaginaEditar
        [HttpGet]
        public ActionResult Editar(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction("Inicio", "ControlGeneral");
            }
            ControlGeneral ocontrolgeneral = olista.Where(c => c.ID_Control == ID).FirstOrDefault();
            return View(ocontrolgeneral);
        }
        #endregion

        #region MetodoGetPaginaEliminar
        [HttpGet]
        public ActionResult Eliminar(int? ID)
        {
            if (ID == null)
                return RedirectToAction("Inicio", "ControlGeneral");
            ControlGeneral ocontrolgeneral = olista.Where(c => c.ID_Control == ID).FirstOrDefault();
            return View(ocontrolgeneral);
        }
        #endregion

        #endregion
        // Fin de linea para las llamadas de las view

        #region Metodos POST que llaman a los Store Procedure

        #region MetodoPaginaRegistrar
        [HttpPost]
        public ActionResult Ingresar(ControlGeneral ocontrolgeneral)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarControlGeneral", oconexion);
                cmd.Parameters.AddWithValue("Fecha", Convert.ToDateTime(DateTime.Now.Date.ToString()));
                cmd.Parameters.AddWithValue("Hora", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("Placa", ocontrolgeneral.Placa.ToUpper());
                cmd.Parameters.AddWithValue("Tipo", ocontrolgeneral.Tipo.ToLower());
                cmd.Parameters.AddWithValue("Estado", "Pendiente");
                cmd.Parameters.AddWithValue("Usuario", Session["Usuario"].ToString());
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "ControlGeneral");
        }
        #endregion

        [HttpPost]
        public ActionResult Pagar(ControlGeneral oControlGeneral)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarControl", cone);
                cmd.Parameters.AddWithValue("ID_Control", oControlGeneral.ID_Control);
                cmd.Parameters.AddWithValue("Fecha", oControlGeneral.Fecha);
                cmd.Parameters.AddWithValue("Hora", oControlGeneral.Hora);
                cmd.Parameters.AddWithValue("Placa", oControlGeneral.Placa);
                cmd.Parameters.AddWithValue("Tipo", oControlGeneral.Tipo);
                cmd.Parameters.AddWithValue("Usuario", oControlGeneral.Usuario);
                cmd.Parameters.AddWithValue("Estado", oControlGeneral.Estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "ControlGeneral");
        }

        [HttpPost]
        public ActionResult Editar(ControlGeneral oControlGeneral)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EditarControlGeneral", cone);
                cmd.Parameters.AddWithValue("ID_Control", oControlGeneral.ID_Control);
                cmd.Parameters.AddWithValue("Placa", oControlGeneral.Placa);
                cmd.Parameters.AddWithValue("Tipo", oControlGeneral.Tipo);
                cmd.Parameters.AddWithValue("Usuario", oControlGeneral.Usuario);
                cmd.Parameters.AddWithValue("Estado", oControlGeneral.Estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "ControlGeneral");
        }

        [HttpPost]
        public ActionResult Eliminar(string ID)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarControlGeneral", oconexion);
                cmd.Parameters.AddWithValue("ID_Control", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "ControlGeneral");
        }
        #endregion

    }
}
