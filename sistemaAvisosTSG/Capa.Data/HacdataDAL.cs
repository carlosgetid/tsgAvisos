using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa.EN;

namespace Capa.DAL
{
    public class HacdataDAL
    {
        SqlConnection con = new DBConnection().getConn();
        
        public IEnumerable<SP_LISTAR_AVISOS_Result> listaAvisos()
        {
            List<SP_LISTAR_AVISOS_Result> listadito = new List<SP_LISTAR_AVISOS_Result>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_AVISOS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SP_LISTAR_AVISOS_Result ta = new SP_LISTAR_AVISOS_Result();
                ta.EMPRESA_CODIGO = dr.GetString(0);
                ta.AVISO_CODIGO = dr.GetDecimal(1);
                ta.AVISO_DESCRIPCION = dr.GetString(2);
                ta.AVISO_DETALLE = dr.GetString(3);
                ta.Column1 = dr.GetDateTime(4);
                ta.Column2= dr.GetString(5);
                ta.AVISO_ESTADO_DESCRIP = dr.GetString(6);
                ta.AVISO_TIPO_DESCRIP = dr.GetString(7);

                listadito.Add(ta);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public SP_LISTAR_AVISO_COMPLETO_Result obtenerAviso(string empresa, int aviso)
        {
            SP_LISTAR_AVISO_COMPLETO_Result sp = new SP_LISTAR_AVISO_COMPLETO_Result();
            if (empresa == null)
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
                sp.Column1 = dr.GetDateTime(4);
                sp.Column2= dr.GetString(5);
                sp.AVISO_DETALLE = dr.GetString(6);
            }

            dr.Close(); con.Close();
            return sp;
        }

        public IEnumerable<SP_LISTAR_TIPO_Result> listaTipo()
        {
            List<SP_LISTAR_TIPO_Result> listadito = new List<SP_LISTAR_TIPO_Result>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SP_LISTAR_TIPO_Result ta = new SP_LISTAR_TIPO_Result();
                ta.AVISO_TIPO_DESCRIP = dr.GetString(0);
                ta.AVISO_TIPO_NRO = dr.GetDecimal(1);
                listadito.Add(ta);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public IEnumerable<SP_LISTAR_ESTADO_Result> listaEstado()
        {
            List<SP_LISTAR_ESTADO_Result> listadito = new List<SP_LISTAR_ESTADO_Result>();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ESTADO", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SP_LISTAR_ESTADO_Result ta = new SP_LISTAR_ESTADO_Result();
                ta.AVISO_ESTADO_DESCRIP = dr.GetString(0);
                ta.AVISO_ESTADO_NRO = dr.GetString(1);
                listadito.Add(ta);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public IEnumerable<SP_LISTAR_COMENTARIO_Result> listaComentario(string empresa, int aviso)
        {
            List<SP_LISTAR_COMENTARIO_Result> listadito = new List<SP_LISTAR_COMENTARIO_Result>();
            if (empresa == null)
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
                SP_LISTAR_COMENTARIO_Result sp = new SP_LISTAR_COMENTARIO_Result();
                sp.USUARI_NOMBRES = dr.GetString(0);
                sp.USUARI_APEPAT = dr.GetString(1);
                sp.AVISOCOM_COMENTARIO = dr.GetString(2);
                sp.Column1 = dr.GetDateTime(3);
                sp.Column2= dr.GetString(4);

                listadito.Add(sp);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public IEnumerable<SP_LISTAR_ADJUNTOS_Result> listaAdjunto(string empresa, int aviso)
        {
            List<SP_LISTAR_ADJUNTOS_Result> listadito = new List<SP_LISTAR_ADJUNTOS_Result>();
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
                SP_LISTAR_ADJUNTOS_Result sp = new SP_LISTAR_ADJUNTOS_Result();
                sp.EMPRESA_CODIGO = dr.GetString(0);
                sp.AVISO_CODIGO = dr.GetDecimal(1);
                sp.AVISOARCH_CODIGO = dr.GetDecimal(2);
                sp.AVISO_ARCHIVO = dr.GetString(3);
                sp.AVISO_RUTA = dr.GetString(4);
                
                listadito.Add(sp);
            }

            dr.Close(); con.Close();
            return listadito;
        }

        public bool crearComentario(TBCAS_AVISO_COMENTARIO oComentario)
        {
            bool confirmacion = true;
            SqlCommand cmd = new SqlCommand("SP_NUEVO_COMENTARIO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_empresa", oComentario.EMPRESA_CODIGO);
            cmd.Parameters.AddWithValue("@id_aviso", oComentario.AVISO_CODIGO);
            cmd.Parameters.AddWithValue("@id_usuario", oComentario.AVISOCOM_USUARIO);
            cmd.Parameters.AddWithValue("@AVISOCOM_COMENTARIO", oComentario.AVISOCOM_COMENTARIO);

            con.Open();

            int ok = cmd.ExecuteNonQuery();

            if (ok == 0)
            {
                confirmacion = false;
            }
            return confirmacion;
        }
    }
}
