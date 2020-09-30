using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public partial class TBCAS_AVISOS
    {
        public string EMPRESA_CODIGO { get; set; }
 
        public decimal AVISO_NRO { get; set; }

        public decimal AVISO_TIPO_NRO { get; set; }

        public string AVISO_REGFECHA { get; set; }

        public string AVISO_REGHORA { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
	    public DateTime AVISO_PUBFECHA { get; set; }

        public string AVISO_PUBHORA { get; set; }

        public string AVISO_DESCRIPCION { get; set; }

        public string AVISO_SYS_EST { get; set; }

        public string AVISO_DETALLE { get; set; }
    }
}