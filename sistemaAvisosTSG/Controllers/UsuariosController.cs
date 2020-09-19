using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaAvisosTSG.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult iniciarSesion(String codigo, String pass)
        {
            System.Diagnostics.Debug.WriteLine(codigo);
            System.Diagnostics.Debug.WriteLine(pass);
            return View();
        }
    }
}