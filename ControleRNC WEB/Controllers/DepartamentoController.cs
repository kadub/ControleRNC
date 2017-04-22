using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleRNC_WEB.DataAcessLayer;
using ControleRNC_WEB.Models;

namespace ControleRNC_WEB.Controllers
{
    public class DepartamentoController : Controller
    {
        private ControleRncContext db = new ControleRncContext();

        // GET: Departamentoes
        public ActionResult Index()
        {
            return View(db.Departamentos.ToList());
        }
    }
}
