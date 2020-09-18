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

        public IEnumerable<TBCAS_AVISOS_TIPO> listaTipo()
        {
            List<TBCAS_AVISOS_TIPO> listadito = new List<TBCAS_AVISOS_TIPO>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TBCAS_AVISOS_TIPO ta = new TBCAS_AVISOS_TIPO();
                ta.AVISO_TIPO_DESCRIP = dr.GetString(0);
                ta.AVISO_TIPO_NRO = dr.GetDecimal(1);
                listadito.Add(ta);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public IEnumerable<TBCAS_AVISOS_ESTADO> listaEstado()
        {
            List<TBCAS_AVISOS_ESTADO> listadito = new List<TBCAS_AVISOS_ESTADO>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ESTADO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TBCAS_AVISOS_ESTADO ta = new TBCAS_AVISOS_ESTADO();
                ta.AVISO_ESTADO_DESCRIP = dr.GetString(0);
                ta.AVISO_ESTADO_NRO = dr.GetString(1);
                listadito.Add(ta);
            }

            dr.Close(); con.Close();
            return listadito;
        }


        public ActionResult Index()
        {
            /*para combos*/
            ViewBag.listaTipo = listaTipo();
            ViewBag.listaEstado = listaEstado();


            /*listados*/
            ViewBag.listaAvisos = listaCompleto("1001", 2001);

            /*lista principal*/
            return View(listaAvisos());
        }

        public ActionResult Buscar(string empresa, int aviso)
        {
            SP_LISTAR_AVISO sp= listaCompleto(empresa, aviso);
            return RedirectToAction("Index", new { oSp = sp});
        }

    }
}