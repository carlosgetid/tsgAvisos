using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Capa.EN;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace sistemaAvisosTSG.Controllers
{
    public class HacdataController : Controller
    {
<<<<<<< HEAD
        IEnumerable<TBCAS_AVISOS> listaAvisos()
=======
        SqlConnection con = new SqlConnection("server=DESKTOP-KQLETA7\\SQLEXPRESS;database=BDGEmpresa1TE;uid=sa;pwd=sql");
        //SqlConnection con = new SqlConnection("server=(localdb)\\Servidor;database=BDGEmpresa1TE;uid=sa;pwd=sql");

        public IEnumerable<TBCAS_AVISOS> listaAvisos()
>>>>>>> cfff423b159634cdd69fb461eff3904b5235705c
        {
            HttpClient http = new HttpClient();
            List<TBCAS_AVISOS> listado = new List<TBCAS_AVISOS>();
            http.BaseAddress = new Uri("http://localhost:49438/api/HacdataApi/");
            var request = http.GetAsync("").Result;
            if (request.IsSuccessStatusCode)
            {
<<<<<<< HEAD
                var resultString = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<TBCAS_AVISOS>>(resultString);
=======
                TBCAS_AVISOS ta = new TBCAS_AVISOS();
                ta.EMPRESA_CODIGO = dr.GetString(0);
                ta.AVISO_NRO = dr.GetDecimal(1);
                ta.AVISO_DESCRIPCION = dr.GetString(2);
                ta.AVISO_DETALLE = dr.GetString(3);
                ta.AVISO_PUBFECHA = dr.GetDateTime(4);
                ta.AVISO_PUBHORA = dr.GetString(5);
                ta.AVISO_ESTADO_DESCRIP = dr.GetString(6);
                ta.AVISO_TIPO_DESCRIP = dr.GetString(7);

                System.Diagnostics.Debug.WriteLine(ta.AVISO_PUBFECHA);
                listadito.Add(ta);
>>>>>>> cfff423b159634cdd69fb461eff3904b5235705c
            }
            return listado;
        }

        SP_LISTAR_AVISO_COMPLETO_Result listaCompleto(string empresa = null, decimal aviso = 0)
        {
            SP_LISTAR_AVISO_COMPLETO_Result sp = new SP_LISTAR_AVISO_COMPLETO_Result();
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:49438/api/HacdataApi/");
            var request = http.GetAsync("?empresa=" + empresa + "&aviso=" + aviso).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                sp = JsonConvert.DeserializeObject<SP_LISTAR_AVISO_COMPLETO_Result>(resultString);
            }
            return sp;
        }

        IEnumerable<SP_LISTAR_TIPO_Result> listaTipo()
        {
            HttpClient http = new HttpClient();
            List<SP_LISTAR_TIPO_Result> listado = new List<SP_LISTAR_TIPO_Result>();
            http.BaseAddress = new Uri("http://localhost:49438/api/HacdataApi/");
            var request = http.GetAsync("Tipo").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<SP_LISTAR_TIPO_Result>>(resultString);
            }
            return listado;
        }

        IEnumerable<SP_LISTAR_ESTADO_Result> listaEstado()
        {
            HttpClient http = new HttpClient();
            List<SP_LISTAR_ESTADO_Result> listado = new List<SP_LISTAR_ESTADO_Result>();
            http.BaseAddress = new Uri("http://localhost:49438/api/HacdataApi/");
            var request = http.GetAsync("Estado").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<SP_LISTAR_ESTADO_Result>>(resultString);
            }
            return listado;
        }

        IEnumerable<SP_LISTAR_COMENTARIO_Result> listaComentario(string empresa = null, decimal aviso = 0)
        {
            HttpClient http = new HttpClient();
            List<SP_LISTAR_COMENTARIO_Result> listado = new List<SP_LISTAR_COMENTARIO_Result>();
            http.BaseAddress = new Uri("http://localhost:49438/api/HacdataApi/");
            var request = http.GetAsync("Comentario/?empresa=" + empresa + "&aviso=" + aviso).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<SP_LISTAR_COMENTARIO_Result>>(resultString);
            }
            return listado;
        }

        IEnumerable<SP_LISTAR_ADJUNTOS_Result> listaAdjunto(string empresa = null, decimal aviso = 0)
        {
            HttpClient http = new HttpClient();
            List<SP_LISTAR_ADJUNTOS_Result> listado = new List<SP_LISTAR_ADJUNTOS_Result>();
            http.BaseAddress = new Uri("http://localhost:49438/api/HacdataApi/");
            var request = http.GetAsync("Adjunto/?empresa=" + empresa + "&aviso=" + aviso).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                listado = JsonConvert.DeserializeObject<List<SP_LISTAR_ADJUNTOS_Result>>(resultString);
            }
            return listado;
        }

        bool crearComentario(TBCAS_AVISO_COMENTARIO oComentario)
        {
            HttpClient http = new HttpClient();
            bool confirmacion=false;
            http.BaseAddress = new Uri("http://localhost:49438/api/HacdataApi/");
            var request = http.PostAsync("", oComentario, new JsonMediaTypeFormatter()).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                confirmacion = JsonConvert.DeserializeObject<bool>(resultString);
            }
            return confirmacion;
        }

        [HttpGet]
        public ActionResult Principal(TBCAS_AVISOS oAvisos)
        {
            /*para combos*/
            ViewBag.listaTipo = listaTipo();
            ViewBag.listaEstado = listaEstado();

            /*Usuario*/
            ViewBag.codigoUser = oAvisos.AVISOCOM_USUARIO;

            /*listados*/
            ViewBag.listaAvisos = listaCompleto(oAvisos.EMPRESA_CODIGO, oAvisos.AVISO_CODIGO);
            ViewBag.listaComentario = listaComentario(oAvisos.EMPRESA_CODIGO, oAvisos.AVISO_CODIGO);
            ViewBag.listaAdjunto = listaAdjunto(oAvisos.EMPRESA_CODIGO, oAvisos.AVISO_CODIGO);
            ViewBag.listaAvisosTodos = listaAvisos();

            TBCAS_AVISO_COMENTARIO oComentario = new TBCAS_AVISO_COMENTARIO();
            oComentario.EMPRESA_CODIGO = oAvisos.EMPRESA_CODIGO;
            oComentario.AVISO_CODIGO = oAvisos.AVISO_CODIGO;
            oComentario.AVISOCOM_USUARIO = oAvisos.AVISOCOM_USUARIO;

            /*lista principal*/
            return View(oComentario);
        }

        [HttpPost]
        public ActionResult Principal(TBCAS_AVISO_COMENTARIO oComentario)
        {
            TBCAS_AVISOS oAvisos = new TBCAS_AVISOS();
            oAvisos.EMPRESA_CODIGO= oComentario.EMPRESA_CODIGO;
            oAvisos.AVISO_CODIGO= oComentario.AVISO_CODIGO;
            oAvisos.AVISOCOM_USUARIO = oComentario.AVISOCOM_USUARIO;

            bool ok = crearComentario(oComentario);



            if (ok)
            {
                return RedirectToAction("Principal", "Hacdata", new {
                    EMPRESA_CODIGO = oComentario.EMPRESA_CODIGO,
                    AVISO_CODIGO = oComentario.AVISO_CODIGO,
                    AVISOCOM_USUARIO = oComentario.AVISOCOM_USUARIO
            });
            }
            return View();
        }
    }
}