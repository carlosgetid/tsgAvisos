using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.EN;
using Capa.DAL;

namespace Capa.BLL
{
    public class HacdataBLL
    {
        HacdataDAL hdal = new HacdataDAL();

        public IEnumerable<SP_LISTAR_AVISOS_Result> listarAvisosAll()
        {
            return hdal.listaAvisos();
        }

        public SP_LISTAR_AVISO_COMPLETO_Result obtenerAviso(string empresa, int aviso)
        {
            return hdal.obtenerAviso(empresa, aviso);
        }

        public IEnumerable<SP_LISTAR_TIPO_Result> listaTipo()
        {
            return hdal.listaTipo();
        }

        public IEnumerable<SP_LISTAR_ESTADO_Result> listaEstado()
        {
            return hdal.listaEstado();
        }

        public IEnumerable<SP_LISTAR_COMENTARIO_Result> listaComentario(string empresa, int aviso)
        {
            return hdal.listaComentario(empresa,aviso);
        }

        public IEnumerable<SP_LISTAR_ADJUNTOS_Result> listaAdjunto(string empresa, int aviso)
        {
            return hdal.listaAdjunto(empresa,aviso);
        }

        public string crearComentario(TBCAS_AVISO_COMENTARIO oComentario)
        {
            return hdal.crearComentario(oComentario);
        }
    }
}
