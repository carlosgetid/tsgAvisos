using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sistemaAvisosTSG.Models
{
    public class SP_LISTAR_COMENTARIO
    {
        public string USUARI_NOMBRES { get; set; }
        public string USUARI_APEPAT { get; set; }
        public string AVISOCOM_COMENTARIO { get; set; }

        [DataType(DataType.Date)]
        public DateTime AVISOCOM_FECHA { get; set; }
        public string AVISOCOM_HORA { get; set; }
    }
}