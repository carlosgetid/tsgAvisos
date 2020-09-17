using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public class SP_LISTAR_AVISO
    {
        public string USUARI_NOMBRES { get; set; }
        public string USUARI_APEPAT { get; set; }
        public decimal AVISO_CODIGO { get; set; }
        public string AVISO_PUBFECHA { get; set; }
        public string AVISO_PUBHORA { get; set; }
        public string AVISO_DETALLE { get; set; }
    }
}