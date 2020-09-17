using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public class TBCAS_AVISOS_ARCHIVO_XUSUARIO
    {
        public string EMPRESA_CODIGO { get; set; }
 
        public int AVISO_CODIGO { get; set; }

        public int AVISOARCH_CODIGO { get; set; }

        public string AVISOARCH_USUARIO { get; set; }

        public string AVISOARCH_FECHA { get; set; }

        public string AVISOARCH_HORA { get; set; }

        public string AVISOARCH_SYS_EST { get; set; }

        public string AVISOARCH_SYS_CRE { get; set; }

    }
}