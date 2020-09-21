using sistemaAvisosTSG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaAvisosTSG.Controllers
{
    public class UsuariosController : Controller
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-KQLETA7\\SQLEXPRESS;database=BDGEmpresa1TE;uid=sa;pwd=sql");
        //SqlConnection con = new SqlConnection("server=DESKTOP-KQLETA7\\SQLEXPRESS;database=BDGEmpresa1TE;uid=sa;pwd=sql");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult iniciarSesion(String codigo, String pass)
        {
            int resultado = -1;

            SqlCommand sqlCommand = new SqlCommand("SP_BUSCAR_USUARIO", con);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@p_usuari_codigo", codigo);
            sqlCommand.Parameters.AddWithValue("@p_usuari_pass", pass);

            con.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.codigo = sqlDataReader.GetString(0);
                usuario.pass = sqlDataReader.GetString(1);
                usuario.apellidoPaterno = sqlDataReader.GetString(2);
                usuario.apellidoMaterno = sqlDataReader.GetString(3);
                usuario.nombres = sqlDataReader.GetString(4);
                usuario.correo = sqlDataReader.GetString(5);
                usuario.telefono = sqlDataReader.GetString(6);
                resultado = 1;
            }
            sqlDataReader.Close();
            con.Close();

            if (resultado == 1)
            {
                System.Diagnostics.Debug.WriteLine("correctamente");
                System.Diagnostics.Debug.WriteLine("correctamente");
                System.Diagnostics.Debug.WriteLine("correctamente");
                return RedirectToAction("Index", "Hacdata");
                //return RedirectToAction("Index", "Hacdata", new { pCodigo = codigo, pPass = pass});
            }
            else { 
                System.Diagnostics.Debug.WriteLine("datos invalidos");
                System.Diagnostics.Debug.WriteLine("datos invalidos");
                System.Diagnostics.Debug.WriteLine("datos invalidos");
                return View();
            }
        }
    }
}