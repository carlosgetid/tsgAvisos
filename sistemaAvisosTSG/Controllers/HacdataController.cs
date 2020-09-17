using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using sistemaAvisosTSG.Models;

namespace sistemaAvisosTSG.Controllers
{
    public class HacdataController : Controller
    {
        SqlConnection con = new SqlConnection("server=(localdb)\\servidor;database=BDGEmpresa1TE;uid=sa;pwd=sql");

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar()
        {


            return View();
        }
    }
}