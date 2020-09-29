using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Capa.BLL;
using Capa.EN;

namespace TSG.ServiciosRest.Controllers
{
    public class HacdataController : ApiController
    {
        HacdataBLL bll = new HacdataBLL();
        
        [HttpGet]
        [Route("api/Hacdata")]
        public IEnumerable<SP_LISTAR_AVISOS_Result> Get()
        {
            return bll.listarAvisosAll();
        }

        [HttpGet]
        [Route("api/Hacdata/{empresa}&{aviso}")]
        public SP_LISTAR_AVISO_COMPLETO_Result Get(string empresa,int aviso)
        {
            return bll.obtenerAviso(empresa,aviso);
        }

        [HttpGet]
        [Route("api/Hacdata/Tipo")]
        public IEnumerable<SP_LISTAR_TIPO_Result> GetTipo()
        {
            return bll.listaTipo();
        }

        [HttpGet]
        [Route("api/Hacdata/Estado")]
        public IEnumerable<SP_LISTAR_ESTADO_Result> GetEstado()
        {
            return bll.listaEstado();
        }

        [HttpGet]
        [Route("api/Hacdata/Comentario/{empresa}&{aviso}")]
        public IEnumerable<SP_LISTAR_COMENTARIO_Result> GetComentario(string empresa, int aviso)
        {
            return bll.listaComentario(empresa,aviso);
        }

        [HttpGet]
        [Route("api/Hacdata/Adjunto/{empresa}&{aviso}")]
        public IEnumerable<SP_LISTAR_ADJUNTOS_Result> GetAdjunto(string empresa, int aviso)
        {
            return bll.listaAdjunto(empresa, aviso);
        }

        [HttpPost]
        [Route("api/Hacdata")]
        public string Post(TBCAS_AVISO_COMENTARIO oComentario)
        {
            return bll.crearComentario(oComentario);
        }

    }
}
