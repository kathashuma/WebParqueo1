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
    public class ClienteController : Controller
    {
        public static List<Cliente> olista=new List<Cliente>();
        // GET: Clientes

        #region Metodos Get paginas/views

        public ActionResult Inicio()
        {
            olista.Clear();
            //ADO.net
            using (SqlConnection cone=new SqlConnection(Conexion.StrConecta))
            {
                //Se llama al SP para listar
                SqlCommand cmd = new SqlCommand("SP_ListarCliente", cone);
                cmd.CommandType=CommandType.Text;
                cone.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Cliente oCliente = new Cliente();    // se instancia la clase cliente para llenarla de datos
                        oCliente.ID_Cliente = Convert.ToInt32(dr["ID_Cliente"]);
                        oCliente.Nombre = (dr["Nombre"].ToString());
                        oCliente.Apellidos = (dr["Apellidos"].ToString());
                        oCliente.Telefono = (dr["Telefono"].ToString());
                        oCliente.Correo = (dr["Correo"].ToString());

                        olista.Add(oCliente); //se van agregando los datos a olista
                    }
                }
            }
            return View(olista); // se mandan todos los valores a la lista
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
                return RedirectToAction("Inicio", "Cliente");
            }
            Cliente oCliente = olista.Where(c => c.ID_Cliente == ID).FirstOrDefault();
            return View(oCliente);
        }

        [HttpGet]
        public ActionResult Eliminar(int? ID)
        {
            if (ID == null)
            {
                return RedirectToAction("Inicio", "Cliente");
            }
            Cliente oCliente = olista.Where(c => c.ID_Cliente == ID).FirstOrDefault();
            return View(oCliente);
        }

        #endregion
        // Fin de los metodos GET para paginas/views

        #region Metodos Post de las views

        [HttpPost]
        public ActionResult Registrar(Cliente oCliente)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_RegistrarCliente", cone);
                cmd.Parameters.AddWithValue("Nombre", oCliente.Nombre);
                cmd.Parameters.AddWithValue("Apellidos", oCliente.Apellidos);
                cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                cmd.Parameters.AddWithValue("Correo", oCliente.Correo);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Cliente");
        }

        [HttpPost]
        public ActionResult Editar(Cliente oCliente)
        {
            using (SqlConnection cone = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EditarCliente", cone);
                cmd.Parameters.AddWithValue("ID_Cliente", oCliente.ID_Cliente);
                cmd.Parameters.AddWithValue("Nombre", oCliente.Nombre);
                cmd.Parameters.AddWithValue("Apellidos", oCliente.Apellidos);
                cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                cmd.Parameters.AddWithValue("Correo", oCliente.Correo);
                cmd.CommandType = CommandType.StoredProcedure;
                cone.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Cliente");
        }

        [HttpPost]
        public ActionResult Eliminar(string ID)
        {
            using (SqlConnection oconexion = new SqlConnection(Conexion.StrConecta))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarCliente", oconexion);
                cmd.Parameters.AddWithValue("ID_Cliente", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Inicio", "Cliente");
        }

        #endregion

    }
}