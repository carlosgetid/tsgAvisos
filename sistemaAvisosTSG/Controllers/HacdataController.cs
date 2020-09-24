﻿using System;
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
                ta.AVISO_PUBFECHA = dr.GetString(4);
                ta.AVISO_PUBHORA = dr.GetString(5);
                ta.AVISO_ESTADO_DESCRIP = dr.GetString(6);
                ta.AVISO_TIPO_DESCRIP = dr.GetString(7);

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
            
            SqlCommand cmd = new SqlCommand("SP_LISTAR_AVISO_COMPLETO", con);
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

        public IEnumerable<TBCAS_AVISOS> listaTipo()
        {
            List<TBCAS_AVISOS> listadito = new List<TBCAS_AVISOS>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TBCAS_AVISOS ta = new TBCAS_AVISOS();
                ta.AVISO_TIPO_DESCRIP = dr.GetString(0);
                ta.AVISO_TIPO_NRO = dr.GetDecimal(1);
                listadito.Add(ta);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public IEnumerable<TBCAS_AVISOS> listaEstado()
        {
            List<TBCAS_AVISOS> listadito = new List<TBCAS_AVISOS>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ESTADO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TBCAS_AVISOS ta = new TBCAS_AVISOS();
                ta.AVISO_ESTADO_DESCRIP = dr.GetString(0);
                ta.AVISO_SYS_EST = dr.GetString(1);
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

        public ActionResult Index(string pEmpresa=null,int pAviso=0,string pHtmlCodigo = null,string pMensaje=null)
        {
            /*para combos*/
            ViewBag.listaTipo = listaTipo();
            ViewBag.listaEstado = listaEstado();

            /*Usuario*/
            ViewBag.codigoUser = pHtmlCodigo;

            /*listados*/
            ViewBag.listaAvisos = listaCompleto(pEmpresa, pAviso);
            ViewBag.listaComentario = listaComentario(pEmpresa, pAviso);
            ViewBag.listaAdjunto = listaAdjunto(pEmpresa, pAviso);

            /*lista principal*/
            return View(listaAvisos());
        }

        public ActionResult Buscar(string empresa, int aviso, string pCodigo = null)
        {
            return RedirectToAction("Index", new { pEmpresa = empresa , pAviso = aviso , pHtmlCodigo = pCodigo });
        }

        public ActionResult crearComentario(TBCAS_AVISO_COMENTARIO oComentario)
        {
            string mensaje = "Registo exitoso";
            SqlCommand cmd = new SqlCommand("SP_NUEVO_COMENTARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_empresa", oComentario.EMPRESA_CODIGO);
            cmd.Parameters.AddWithValue("@id_aviso", oComentario.AVISO_CODIGO);
            cmd.Parameters.AddWithValue("@id_usuario", oComentario.AVISOCOM_USUARIO);
            cmd.Parameters.AddWithValue("@AVISOCOM_COMENTARIO", oComentario.AVISOCOM_COMENTARIO);

            con.Open();

            int ok=cmd.ExecuteNonQuery();

            if (ok == 0)
            {
                mensaje = "No registrado";
            }
            return RedirectToAction("Index", new { pEmpresa = oComentario.EMPRESA_CODIGO, pAviso = oComentario.AVISO_CODIGO, pMensaje=mensaje, pHtmlCodigo = oComentario.AVISOCOM_USUARIO });
        }

    }
}