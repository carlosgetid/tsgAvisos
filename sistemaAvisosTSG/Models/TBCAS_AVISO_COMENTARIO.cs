using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public class TBCAS_AVISO_COMENTARIO
    {
        public string EMPRESA_CODIGO { get; set; }

        public decimal AVISO_CODIGO { get; set; }

        public int AVISOCOM_ID { get; set; }

        public string AVISOCOM_USUARIO { get; set; }

        public string AVISOCOM_COMENTARIO { get; set; }

        public string AVISOCOM_FECHA { get; set; }

        public string AVISOCOM_HORA { get; set; }

        public string AVISOCOM_SYS_EST { get; set; }

        public string AVISOCOM_SYS_CRE { get; set; }
}
}