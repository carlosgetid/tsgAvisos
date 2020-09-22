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
        SqlConnection con = new SqlConnection("server=DESKTOP-KQLETA7\\SQLEXPRESS;database=BDGEmpresa1TE;uid=sa;pwd=sql");
        //SqlConnection con = new SqlConnection("server=(localdb)\\Servidor;database=BDGEmpresa1TE;uid=sa;pwd=sql");

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

        public SP_LISTAR_AVISO listaCompleto(string empresa=null, int aviso=0)
        {
            SP_LISTAR_AVISO sp = new SP_LISTAR_AVISO();
            if (empresa==null)
            {
                return sp;
            }
            
            SqlCommand cmd = new SqlCommand("SP_LISTAR_AVISO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empresa_codigo", empresa);
            cmd.Parameters.AddWithValue("@aviso_numero", aviso);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                sp.AVISO_CODIGO = dr.GetDecimal(0);
                sp.EMPRESA_CODIGO = dr.GetString(1);
                sp.USUARI_NOMBRES = dr.GetString(2);
                sp.USUARI_APEPAT = dr.GetString(3);
                sp.AVISO_PUBFECHA = dr.GetString(4);
                sp.AVISO_PUBHORA = dr.GetString(5);
                sp.AVISO_DETALLE = dr.GetString(6);
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

        public IEnumerable<SP_LISTAR_COMENTARIO> listaComentario(string empresa=null, int aviso=0)
        {
            List<SP_LISTAR_COMENTARIO> listadito = new List<SP_LISTAR_COMENTARIO>();
            if (empresa==null)
            {
                return listadito;
            }
            SqlCommand cmd = new SqlCommand("SP_LISTAR_COMENTARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empresa_codigo", empresa);
            cmd.Parameters.AddWithValue("@aviso_numero", aviso);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SP_LISTAR_COMENTARIO sp = new SP_LISTAR_COMENTARIO();
                sp.USUARI_NOMBRES = dr.GetString(0);
                sp.USUARI_APEPAT = dr.GetString(1);
                sp.AVISOCOM_COMENTARIO = dr.GetString(2);
                sp.AVISOCOM_FECHA = dr.GetString(3);
                sp.AVISOCOM_HORA = dr.GetString(4);

                listadito.Add(sp);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public IEnumerable<SP_LISTAR_ADJUNTOS> listaAdjunto(string empresa=null, int aviso=0)
        {
            List<SP_LISTAR_ADJUNTOS> listadito = new List<SP_LISTAR_ADJUNTOS>();
            if (empresa == null)
            {
                return listadito;
            }
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ADJUNTOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empresa_codigo", empresa);
            cmd.Parameters.AddWithValue("@aviso_numero", aviso);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SP_LISTAR_ADJUNTOS sp = new SP_LISTAR_ADJUNTOS();
                sp.EMPRESA_CODIGO = dr.GetString(0);
                sp.AVISO_CODIGO= dr.GetDecimal(1);
                sp.AVISOARCH_CODIGO = dr.GetDecimal(2);
                sp.AVISO_ARCHIVO = dr.GetString(3);
                sp.AVISO_RUTA = dr.GetString(4);
                

                listadito.Add(sp);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public ActionResult Index(string pEmpresa=null,int pAviso=0,string pCodigo=null)
        {
            /*para combos*/
            ViewBag.listaTipo = listaTipo();
            ViewBag.listaEstado = listaEstado();

            /*listados*/
            ViewBag.listaAvisos = listaCompleto(pEmpresa, pAviso);
            ViewBag.listaComentario = listaComentario(pEmpresa, pAviso);
            ViewBag.listaAdjunto = listaAdjunto(pEmpresa, pAviso);

            /*lista principal*/
            return View(listaAvisos());
        }

        public ActionResult Buscar(string empresa, int aviso)
        {
            return RedirectToAction("Index", new { pEmpresa = empresa , pAviso = aviso });
        }

    }
}