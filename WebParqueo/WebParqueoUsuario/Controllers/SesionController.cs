using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebParqueoUsuario.Models;

public class SesionController : Controller
{
    public ActionResult LoginPage()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(Usuarios vUsuarios)
    {
        using (SqlConnection oconexion = new SqlConnection(Conexion.StrConecta))
        {
            SqlCommand cmd = new SqlCommand("SP_VerificaUsuario", oconexion);
            cmd.Parameters.AddWithValue("@Usuario", vUsuarios.Usuario);
            cmd.Parameters.AddWithValue("@Clave", vUsuarios.Clave);
            cmd.CommandType = CommandType.StoredProcedure;

            oconexion.Open();
            vUsuarios.ID_Usuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
        }
        if (vUsuarios.ID_Usuario != 0)
        {
            Session["usuario"] = vUsuarios.Usuario;
            return RedirectToAction("Inicio", "ControlGeneral");
        }
        else
        {
            return RedirectToAction("LoginPage", "Sesion");
        }

    }

    public ActionResult CerrarSesion()
    {
        Session["usuario"] = null;
        return RedirectToAction("LoginPage", "Sesion");
    }
}
