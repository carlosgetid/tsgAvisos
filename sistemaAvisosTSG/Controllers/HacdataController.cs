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

            dr.Close(); con.Close();
            return listadito;
        }

        public SP_LISTAR_AVISO listaCompleto(string empresa, int aviso)
        {
            SP_LISTAR_AVISO sp = new SP_LISTAR_AVISO();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_AVISO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empresa_codigo", empresa);
            cmd.Parameters.AddWithValue("@aviso_numero", aviso);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sp.USUARI_NOMBRES = dr.GetString(0);
                sp.USUARI_APEPAT = dr.GetString(1);
                sp.AVISO_CODIGO = dr.GetDecimal(2);
                sp.AVISO_PUBFECHA = dr.GetString(3);
                sp.AVISO_PUBHORA = dr.GetString(4);
                sp.AVISO_DETALLE = dr.GetString(5);
            }

            dr.Close(); con.Close();
            return sp;
        }

        public ActionResult Index(SP_LISTAR_AVISO sp)
        {
            ViewBag.listaAvisos = sp.AVISO_CODIGO;
            return View(listaAvisos());
        }

        [HttpPost]
        public ActionResult Index (string empresa, int aviso)
        {
            SP_LISTAR_AVISO sp= listaCompleto(empresa, aviso);
            return Index(sp);
        }

    }
}