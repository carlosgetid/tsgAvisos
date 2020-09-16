using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaAvisosTSG.Controllers
{
    public class AvisosController : Controller
    {
        // GET: Avisos
        public ActionResult Index()
        {
            return View();
        }
    }
}