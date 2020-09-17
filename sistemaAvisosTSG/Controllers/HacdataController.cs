using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using sistemaAvisosTSG.Models;

namespace sistemaAvisosTSG.Controllers
{
    public class HacdataController : Controller
    {
        SqlConnection con = new SqlConnection("server=(localdb)\\servidor;database=BDGEmpresa1TE;uid=sa;pwd=sql");

        public IEnumerable<TBCAS_AVISOS> listaAvisos()
        {
            List<TBCAS_AVISOS> listadito = new List<TBCAS_AVISOS>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_AVISOS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TBCAS_AVISOS ta = new TBCAS_AVISOS();
                ta.EMPRESA_CODIGO = dr.GetString(0);
                ta.AVISO_NRO = dr.GetDecimal(1);
                ta.AVISO_DESCRIPCION = dr.GetString(2);
                ta.AVISO_DETALLE = dr.GetString(3);

                listadito.Add(ta);
            }

            dr.Close();con.Close();
            return listadito;
        }

        public ActionResult Index()
        {
            return View(listaAvisos());
        }

        [HttpPost]
        public ActionResult Buscar(int tipo,string fecha,int estado)
        {
            SqlCommand cmd = new SqlCommand("SP_BUSQUEDA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo", tipo);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@estado", estado);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

            }

            return View();
        }
    }
}