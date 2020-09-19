using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaAvisosTSG.Models
{
    public class Usuario
    {
        public String codigo { get; set; }
        public String pass { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
        public String nombres { get; set; }
        public String correo { get; set; }
        public String telefono { get; set; }
    }
}