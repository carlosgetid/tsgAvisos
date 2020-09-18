using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public class SP_LISTAR_ADJUNTOS
    {
        public string EMPRESA_CODIGO { get; set; }
        public decimal AVISO_CODIGO { get; set; }
        public decimal AVISOARCH_CODIGO { get; set; }
        public string AVISO_ARCHIVO { get; set; }
        public string AVISO_RUTA { get; set; }
    }
}