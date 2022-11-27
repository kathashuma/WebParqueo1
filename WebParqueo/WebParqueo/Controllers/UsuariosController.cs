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
    public class UsuariosController : Controller
    {
        public static List<Usuarios> ulista = new List<Usuarios>();
        // GET: Clientes

        #region Metodos Get paginas/views

        public ActionResult Inicio()
        {
            ulista.Clear();
            //ADO.net
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                //Se llama al SP para listar
                SqlCommand cmd = new SqlCommand("SP_ListarUsuarios", cone);
                cmd.CommandType = CommandType.Text;
                cone.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuarios oUsuarios = new Usuarios();    // se instancia la clase cliente para llenarla de datos
                        oUsuarios.ID_Usuario = Convert.ToInt32(dr["ID_Usuario"]);
                        oUsuarios.Usuario = (dr["Usuario"].ToString());
                        oUsuarios.Clave = (dr["Clave"].ToString());
                        oUsuarios.NivelUsuario = Convert.ToInt32(dr["NivelUsuario"]);

                        ulista.Add(oUsuarios); //se van agregando los datos a olista
                    }
                }
            }
            return View(ulista); // se mandan todos los valores a la lista
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
                return RedirectToAction("Inicio", "Usuarios");
            }
            Usuarios oUsuarios = ulista.Where(c => c.ID_Usuario == ID).FirstOrDefault();
            return View(oUsuarios);
        }

        [HttpGet]
        public ActionResult Eliminar(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction("Inicio", "Usuarios");
            }
            Usuarios oUsuarios = ulista.Where(c => c.ID_Usuario == ID).FirstOrDefault();
            return View(oUsuarios);
        }

        #endregion
        // Fin de los metodos GET para paginas/views

        #region Metodos Post de las views

        [HttpPost]
        public ActionResult Registrar(Usuarios oUsuarios)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarUsuarios", cone);
                cmd.Parameters.AddWithValue("Usuario", oUsuarios.Usuario);
                cmd.Parameters.AddWithValue("Clave", oUsuarios.Clave);
                cmd.Parameters.AddWithValue("NivelUsuario", oUsuarios.NivelUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Usuarios");
        }

        [HttpPost]
        public ActionResult Editar(Usuarios oUsuarios)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EditarUsuarios", cone);
                cmd.Parameters.AddWithValue("ID_Usuario", oUsuarios.ID_Usuario);
                cmd.Parameters.AddWithValue("Usuario", oUsuarios.Usuario);
                cmd.Parameters.AddWithValue("Clave", oUsuarios.Clave);
                cmd.Parameters.AddWithValue("NivelUsuario", oUsuarios.NivelUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Usuarios");
        }

        [HttpPost]
        public ActionResult Eliminar(string ID)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarUsuarios", oconexion);
                cmd.Parameters.AddWithValue("ID_Usuario", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Usuarios");
        }

        #endregion

    }
}