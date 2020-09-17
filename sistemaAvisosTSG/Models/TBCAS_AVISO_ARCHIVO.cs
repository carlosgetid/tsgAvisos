using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public class TBCAS_AVISO_ARCHIVO
    {
        public string EMPRESA_CODIGO { get; set; }
        public int AVISO_CODIGO { get; set; }
        public string AVISO_ARCHIVO { get; set; }
        public string AVISO_RUTA { get; set; }
        public string AVISO_SYS_CRE { get; set; }
        public string AVISO_SYS_EST { get; set; }
        public int AVISOARCH_CODIGO { get; set; }
        public int AVISOARCH_NROVECES { get; set; }
    }
}