using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public class TBCAS_AVISOS
    {
        public string EMPRESA_CODIGO { get; set; }
 
        public int AVISO_NRO { get; set; }

        public int AVISO_TIPO_NRO { get; set; }

        public string AVISO_REGFECHA { get; set; }

        public string AVISO_REGHORA { get; set; }
    
	    public string AVISO_PUBFECHA { get; set; }

        public string AVISO_PUBHORA { get; set; }

        public string AVISO_DESCRIPCION { get; set; }

        public int AVISO_ESTADO_NRO { get; set; }

        public string AVISO_SYS_EST { get; set; }

        public string AVISO_DETALLE { get; set; }
    }
}